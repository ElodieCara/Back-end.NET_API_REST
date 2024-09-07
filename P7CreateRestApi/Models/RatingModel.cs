using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class RatingModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "La notation Moody's ne peut pas dépasser 50 caractères.")]
        public string MoodysRating { get; set; }

        [StringLength(50, ErrorMessage = "La notation S&P ne peut pas dépasser 50 caractères.")]
        public string SandPRating { get; set; }

        [StringLength(50, ErrorMessage = "La notation Fitch ne peut pas dépasser 50 caractères.")]
        public string FitchRating { get; set; }

        [Range(0, byte.MaxValue, ErrorMessage = "Le numéro de commande doit être un nombre valide.")]
        public byte? OrderNumber { get; set; }
    }
}
