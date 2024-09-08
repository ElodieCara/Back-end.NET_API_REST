using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dot.Net.WebApi.Domain
{
    [Table("Trades")]
    public class Trade
    {
        [Key]
        [Column("Trade_Id")]
        public int TradeId { get; set; }

        [Column("Account")]
        public string? Account { get; set; }

        [Column("Account_Type")]
        public string? AccountType { get; set; }

        [Column("Buy_Quantity")]
        public double? BuyQuantity { get; set; }

        [Column("Sell_Quantity")]
        public double? SellQuantity { get; set; }

        [Column("Buy_Price")]
        public double? BuyPrice { get; set; }

        [Column("Sell_Price")]
        public double? SellPrice { get; set; }

        [Column("Trade_Date")]
        public DateTime? TradeDate { get; set; }

        [Column("Trade_Security")]
        public string? TradeSecurity { get; set; }

        [Column("Trade_Status")]
        public string? TradeStatus { get; set; }

        [Column("Trader")]
        public string? Trader { get; set; }

        [Column("Benchmark")]
        public string? Benchmark { get; set; }

        [Column("Book")]
        public string? Book { get; set; }

        [Column("Creation_Name")]
        public string? CreationName { get; set; }

        [Column("Creation_Date")]
        public DateTime? CreationDate { get; set; }

        [Column("Revision_Name")]
        public string? RevisionName { get; set; }

        [Column("Revision_Date")]
        public DateTime? RevisionDate { get; set; }

        [Column("Deal_Name")]
        public string? DealName { get; set; }

        [Column("Deal_Type")]
        public string? DealType { get; set; }

        [Column("Source_List_Id")]
        public string? SourceListId { get; set; }

        [Column("Side")]
        public string? Side { get; set; }

        // Clé étrangère vers User
        [ForeignKey("User")]
        [Column("User_Id")]
        public string UserId { get; set; }
        public User User { get; set; }

        // Clé étrangère vers Rating
        [ForeignKey("Rating")]
        [Column("Rating_Id")]
        public int? RatingId { get; set; }
        public Rating? Rating { get; set; }  // Relation avec Rating

        // Clé étrangère vers BidList
        [ForeignKey("BidList")]
        [Column("BidList_Id")]
        public int BidListId { get; set; }
        public BidList BidList { get; set; }
    }
}

