using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dot.Net.WebApi.Domain
{
    [Table("BidLists")]
    public class BidList
    {
        [Key]
        [Column("BidList_Id")]
        public int BidListId { get; set; }

        [ForeignKey("Rating")]
        [Column("Rating_Id")]  // Clé étrangère avec Rating
        public int? RatingId { get; set; }

        public Rating? Rating { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Account")]
        public string Account { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column("Bid_Type")]
        public string BidType { get; set; } = string.Empty;

        [Column("Bid_Quantity")]
        public double? BidQuantity { get; set; }

        [Column("Ask_Quantity")]
        public double? AskQuantity { get; set; }

        [Column("Bid")]
        public double? Bid { get; set; }

        [Column("Ask")]
        public double? Ask { get; set; }

        [StringLength(100)]
        [Column("Benchmark")]
        public string Benchmark { get; set; } = string.Empty;

        [Column("BidList_Date")]
        public DateTime? BidListDate { get; set; }

        [StringLength(200)]
        [Column("Commentary")]
        public string Commentary { get; set; } = string.Empty;

        [StringLength(100)]
        [Column("Bid_Security")]
        public string BidSecurity { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Bid_Status")]
        public string BidStatus { get; set; } = string.Empty;

        [StringLength(100)]
        [Column("Trader_Name")]
        public string Trader { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Book")]
        public string Book { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Creation_Name")]
        public string CreationName { get; set; } = string.Empty;

        [Column("Creation_Date")]
        public DateTime? CreationDate { get; set; }

        [StringLength(50)]
        [Column("Revision_Name")]
        public string RevisionName { get; set; } = string.Empty;

        [Column("Revision_Date")]
        public DateTime? RevisionDate { get; set; }

        [StringLength(100)]
        [Column("Deal_Name")]
        public string DealName { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Deal_Type")]
        public string DealType { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Source_List_Id")]
        public string SourceListId { get; set; } = string.Empty;

        [StringLength(10)]
        [Column("Side")]
        public string Side { get; set; } = string.Empty;

        // Relation avec les Trades
        public ICollection<Trade> Trades { get; set; } = new List<Trade>();
    }

}
