using System;
using System.ComponentModel.DataAnnotations;

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

        [Range(0, double.MaxValue, ErrorMessage = "La quantité d'achat doit être positive.")]
        public double? BuyQuantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "La quantité de vente doit être positive.")]
        public double? SellQuantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix d'achat doit être positif.")]
        public double? BuyPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix de vente doit être positif.")]
        public double? SellPrice { get; set; }

        public DateTime? TradeDate { get; set; }

        [StringLength(100, ErrorMessage = "La sécurité de l'échange ne peut pas dépasser 100 caractères.")]
        public string TradeSecurity { get; set; }

        [StringLength(50, ErrorMessage = "Le statut ne peut pas dépasser 50 caractères.")]
        public string TradeStatus { get; set; }

        [StringLength(100, ErrorMessage = "Le nom du trader ne peut pas dépasser 100 caractères.")]
        public string Trader { get; set; }

        [StringLength(100, ErrorMessage = "La référence ne peut pas dépasser 100 caractères.")]
        public string Benchmark { get; set; }

        [StringLength(50, ErrorMessage = "Le nom du livre ne peut pas dépasser 50 caractères.")]
        public string Book { get; set; }

        [StringLength(50, ErrorMessage = "Le nom du créateur ne peut pas dépasser 50 caractères.")]
        public string CreationName { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(50, ErrorMessage = "Le nom du réviseur ne peut pas dépasser 50 caractères.")]
        public string RevisionName { get; set; }

        public DateTime? RevisionDate { get; set; }

        [StringLength(100, ErrorMessage = "Le nom de l'affaire ne peut pas dépasser 100 caractères.")]
        public string DealName { get; set; }

        [StringLength(50, ErrorMessage = "Le type d'affaire ne peut pas dépasser 50 caractères.")]
        public string DealType { get; set; }

        [StringLength(50, ErrorMessage = "L'ID de la liste source ne peut pas dépasser 50 caractères.")]
        public string SourceListId { get; set; }

        [StringLength(10, ErrorMessage = "Le côté ne peut pas dépasser 10 caractères.")]
        public string Side { get; set; }

        // Relation possible avec User ou autre entité
    }
}
