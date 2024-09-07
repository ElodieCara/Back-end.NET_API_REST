using System;
using System.ComponentModel.DataAnnotations;

namespace Dot.Net.WebApi.Models
{
    public class BidListModel
    {
        [Key]
        public int BidListId { get; set; }

        [Required(ErrorMessage = "Le compte est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le compte ne peut pas dépasser 50 caractères.")]
        public string Account { get; set; }

        [StringLength(50)]
        public string BidType { get; set; }

        public double? BidQuantity { get; set; }
        public double? AskQuantity { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }

        [StringLength(100)]
        public string Benchmark { get; set; }

        public DateTime? BidListDate { get; set; }

        [StringLength(200)]
        public string Commentary { get; set; }

        [StringLength(100)]
        public string BidSecurity { get; set; }

        [StringLength(50)]
        public string BidStatus { get; set; }

        [StringLength(100)]
        public string Trader { get; set; }

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
    }
}
