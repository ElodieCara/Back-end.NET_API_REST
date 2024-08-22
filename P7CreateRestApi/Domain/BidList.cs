using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Domain
{
    public class BidList
    {
        public int BidListId { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string BidType { get; set; } = string.Empty;

        public double? BidQuantity { get; set; }
        public double? AskQuantity { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }

        [StringLength(100)]
        public string Benchmark { get; set; } = string.Empty;

        public DateTime? BidListDate { get; set; }

        [StringLength(200)]
        public string Commentary { get; set; } = string.Empty;

        [StringLength(100)]
        public string BidSecurity { get; set; } = string.Empty;

        [StringLength(50)]
        public string BidStatus { get; set; } = string.Empty;

        [StringLength(100)]
        public string Trader { get; set; } = string.Empty;

        [StringLength(50)]
        public string Book { get; set; } = string.Empty;

        [StringLength(50)]
        public string CreationName { get; set; } = string.Empty;

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string RevisionName { get; set; } = string.Empty;

        public DateTime? RevisionDate { get; set; }

        [StringLength(100)]
        public string DealName { get; set; } = string.Empty;

        [StringLength(50)]
        public string DealType { get; set; } = string.Empty;

        [StringLength(50)]
        public string SourceListId { get; set; } = string.Empty;

        [StringLength(10)]
        public string Side { get; set; } = string.Empty;
    }
}
