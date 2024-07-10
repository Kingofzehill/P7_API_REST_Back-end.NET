using System.ComponentModel.DataAnnotations;
namespace P7CreateRestApi.Models.InputModels
{
    /// <summary>
    /// BidList POCO Class for input model.
    /// </summary>
    /// <remarks></remarks>
    public class BidListInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string BidType { get; set; }
        public double? BidQuantity { get; set; }
        public double? AskQuantity { get; set; }
        public double? Bid { get; set; }
        public double? Ask { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Benchmark { get; set; }
        public DateTime? BidListDate { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Commentary { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string BidSecurity { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string BidStatus { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Trader { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Book { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string CreationName { get; set; }
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
