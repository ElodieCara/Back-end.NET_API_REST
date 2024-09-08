using System.ComponentModel.DataAnnotations;
using Dot.Net.WebApi.Domain;


namespace Dot.Net.WebApi.Models
{
    public class TradeModel
    {
        [Key]
        public int TradeId { get; set; }

        [Required(ErrorMessage = "Le compte est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le compte ne peut pas dépasser 50 caractères.")]
        public string Account { get; set; }

        [Required(ErrorMessage = "Le type de compte est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le type de compte ne peut pas dépasser 50 caractères.")]
        public string AccountType { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "La quantité d'achat doit être supérieure à 0.")]
        public double? BuyQuantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "La quantité de vente doit être supérieure à 0.")]
        public double? SellQuantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix d'achat doit être supérieur à 0.")]
        public double? BuyPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix de vente doit être supérieur à 0.")]
        public double? SellPrice { get; set; }

        [DataType(DataType.DateTime)]
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

        // Relation avec User
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

