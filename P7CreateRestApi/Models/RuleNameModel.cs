using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class RuleNameModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "La description ne peut pas dépasser 255 caractères.")]
        public string Description { get; set; }

        [StringLength(1000, ErrorMessage = "Le JSON ne peut pas dépasser 1000 caractères.")]
        public string Json { get; set; }

        [StringLength(1000, ErrorMessage = "Le template ne peut pas dépasser 1000 caractères.")]
        public string Template { get; set; }

        [StringLength(1000, ErrorMessage = "Le SQL ne peut pas dépasser 1000 caractères.")]
        public string SqlStr { get; set; }

        [StringLength(1000, ErrorMessage = "Le SQLPart ne peut pas dépasser 1000 caractères.")]
        public string SqlPart { get; set; }
    }
}
