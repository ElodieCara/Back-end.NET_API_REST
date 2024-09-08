using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dot.Net.WebApi.Domain
{
    [Table("Ratings")]
    public class Rating
    {
        [Key]
        [Column("Rating_Id")]
        public int Id { get; set; }

        [StringLength(50)]
        [Column("Moodys_Rating")]
        public string MoodysRating { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("SAndP_Rating")]
        public string SandPRating { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Fitch_Rating")]
        public string FitchRating { get; set; } = string.Empty;

        [Column("Order_Number")]
        public byte? OrderNumber { get; set; }

        // Relations avec Trades et BidLists
        public ICollection<Trade> Trades { get; set; }
        public ICollection<BidList> BidLists { get; set; }
    }
}

