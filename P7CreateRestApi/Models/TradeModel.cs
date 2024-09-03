using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class TradeModel
    {
        public int TradeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountType { get; set; }

        public double? BuyQuantity { get; set; }
        public double? SellQuantity { get; set; }
        public double? BuyPrice { get; set; }
        public double? SellPrice { get; set; }

        public DateTime? TradeDate { get; set; }

        [StringLength(100)]
        public string TradeSecurity { get; set; }

        [StringLength(50)]
        public string TradeStatus { get; set; }

        [StringLength(100)]
        public string Trader { get; set; }

        [StringLength(100)]
        public string Benchmark { get; set; }

        [StringLength(50)]
        public string Book { get; set; }

        [StringLength(50)]
        public string CreationName { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        public string RevisionName { get; set; }

        public DateTime? RevisionDate { get; set; }

        [StringLength(100)]
        public string DealName { get; set; }

        [StringLength(50)]
        public string DealType { get; set; }

        [StringLength(50)]
        public string SourceListId { get; set; }

        [StringLength(10)]
        public string Side { get; set; }

        // Relation possible avec User ou autre entité
    }
}
