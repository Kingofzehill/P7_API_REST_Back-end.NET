using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModel
{
    public class RuleNameInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Json { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Template { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string SqlStr { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string SqlPart { get; set; }
    }
}
