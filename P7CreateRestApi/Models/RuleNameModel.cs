using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class RuleNameModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Json { get; set; }

        public string Template { get; set; }

        public string SqlStr { get; set; }

        public string SqlPart { get; set; }
    }
}
