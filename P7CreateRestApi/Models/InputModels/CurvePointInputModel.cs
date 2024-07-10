using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModel
{
    public class CurvePointInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public byte? CurveId { get; set; }
        public DateTime? AsOfDate { get; set; }
        public double? Term { get; set; }
        public double? CurvePointValue { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
