using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModel
{
    public class RatingInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string MoodysRating { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string SandPRating { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string FitchRating { get; set; }
        public byte? OrderNumber { get; set; }
    }
}
