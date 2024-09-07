using System.ComponentModel.DataAnnotations;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Models
{
    public class UserModel
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom d'utilisateur est obligatoire.")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom complet est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom complet ne peut pas dépasser 100 caractères.")]
        public string Fullname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir entre 6 et 100 caractères.")]
        public string Password {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Le rôle est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le rôle ne peut pas dépasser 50 caractères.")]
        public string Role { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
        // Relation avec BidList, Trade, etc.
        public ICollection<BidList> BidLists { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }
}
