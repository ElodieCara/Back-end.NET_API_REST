using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class CurvePointModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'ID de la courbe est obligatoire.")]
        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }

        [Required(ErrorMessage = "Le terme est obligatoire.")]
        public double? Term { get; set; }

        [Required(ErrorMessage = "La valeur du point de courbe est obligatoire.")]
        public double? CurvePointValue { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
