namespace Dot.Net.WebApi.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
