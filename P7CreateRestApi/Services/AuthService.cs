using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Dot.Net.WebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.Password))
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname,
                Role = user.Role
            };
        }

        public async Task<UserDTO> Register(UserDTO userDto)
        {
            if (await UserExists(userDto.Username))
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Username = userDto.Username,
                Password = HashPassword(userDto.Password),
                Fullname = userDto.Fullname,
                Role = userDto.Role
            };

            await _userRepository.AddAsync(user);
            userDto.Id = user.Id;
            return userDto;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _userRepository.GetByUsernameAsync(username) != null;
        }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return HashPassword(enteredPassword) == hashedPassword;
        }
    }
}
