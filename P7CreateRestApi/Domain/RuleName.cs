using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dot.Net.WebApi.Domain 
{ 
    [Table("RuleNames")]
    public class RuleName
    {
        [Key]
        [Column("RuleName_Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        [Column("Description")]
        public string Description { get; set; } = string.Empty;

        [Column("Json")]
        public string Json { get; set; } = string.Empty;

        [Column("Template")]
        public string Template { get; set; } = string.Empty;

        [Column("Sql_Str")]
        public string SqlStr { get; set; } = string.Empty;

        [Column("Sql_Part")]
        public string SqlPart { get; set; } = string.Empty;
    }
}
