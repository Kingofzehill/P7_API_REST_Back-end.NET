using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModel
{
    public class TradeInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string AccountType { get; set; }
        public double? BuyQuantity { get; set; }
        public double? SellQuantity { get; set; }
        public double? BuyPrice { get; set; }
        public double? SellPrice { get; set; }
        public DateTime? TradeDate { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string TradeSecurity { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string TradeStatus { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Trader { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Benchmark { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Book { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string CreationName { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public DateTime? CreationDate { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string RevisionName { get; set; }
        public DateTime? RevisionDate { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string DealName { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string DealType { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string SourceListId { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Side { get; set; }
    }
}
