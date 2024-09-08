using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dot.Net.WebApi.Domain
{
    [Table("CurvePoints")]
    public class CurvePoint
    {
        [Key]
        [Column("CurvePoint_Id")]
        public int Id { get; set; }

        [Column("Curve_Id")]
        public byte? CurveId { get; set; }

        [Column("As_Of_Date")]
        public DateTime? AsOfDate { get; set; }

        [Column("Term")]
        public double? Term { get; set; }

        [Column("CurvePoint_Value")]
        public double? CurvePointValue { get; set; }

        [Column("Creation_Date")]
        public DateTime? CreationDate { get; set; }
    }
}

