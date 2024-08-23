using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IAuthService
    {
        Task<UserDTO> Authenticate(string username, string password);
        Task<UserDTO> Register(UserDTO userDto);
        Task<bool> UserExists(string username);
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string hashedPassword);
    }
}
