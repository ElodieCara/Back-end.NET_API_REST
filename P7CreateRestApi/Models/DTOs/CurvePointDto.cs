namespace P7CreateRestApi.Models.DTOs
{
    public class CurvePointDto
    {
        public int Id { get; set; }
        public byte? CurveId { get; set; }
        public DateTime? AsOfDate { get; set; }
        public double? Term { get; set; }
        public double? CurvePointValue { get; set; }
    }
}
