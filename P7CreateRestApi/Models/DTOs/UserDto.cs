namespace P7CreateRestApi.Models.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; }    
        public string Token { get; set; }
    }
}
