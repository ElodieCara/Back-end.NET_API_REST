using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Dot.Net.WebApi.Domain
{
    [Table("Users")]
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        [Column("Fullname")]
        public string Fullname { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column("Role")]
        public string Role { get; set; } = string.Empty;

        // Relation avec les Trades
        public ICollection<Trade> Trades { get; set; } = new List<Trade>();
    }
}
