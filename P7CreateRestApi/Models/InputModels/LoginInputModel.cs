using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string Password { get; set; }
    }
}
