using System.ComponentModel.DataAnnotations;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Models
{
    public class UserModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Fullname { get; set; } = string.Empty;

        public string Password {  get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
        // Relation avec BidList, Trade, etc.
        public ICollection<BidList> BidLists { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }
}
