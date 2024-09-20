namespace P7CreateRestApi.Models.DTOs
{
    public class LoginOutputDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
