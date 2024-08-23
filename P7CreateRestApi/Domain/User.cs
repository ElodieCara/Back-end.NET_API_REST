using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Domain
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Fullname { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = string.Empty;
    }
}
