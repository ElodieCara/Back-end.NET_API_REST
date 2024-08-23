namespace Dot.Net.WebApi.Models
{
    public class CurvePointDTO
    {
        public int Id { get; set; }
        public byte? CurveId { get; set; }
        public DateTime? AsOfDate { get; set; }
        public double? Term { get; set; }
        public double? CurvePointValue { get; set; }
    }
}
