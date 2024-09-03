using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class RatingModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string MoodysRating { get; set; }

        [StringLength(50)]
        public string SandPRating { get; set; }

        [StringLength(50)]
        public string FitchRating { get; set; }

        public byte? OrderNumber { get; set; }
    }
}
