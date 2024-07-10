using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModel
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [MinLength(4, ErrorMessage = "Le champs {0} doit avoir au moins {1} caractères.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [MinLength(8, ErrorMessage = "Le champs {0} doit avoir au moins {1} caractères.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\d\s]).*$", ErrorMessage = "Le champs {0} doit contenir au moins une lettre majuscule, un chiffre et un symbole.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Le {0} est obligatoire.")]
        [RegularExpression("^(Admin|User)$", ErrorMessage = "Le champs {0} doit être  de valeur 'Admin' ou 'User'.")]
        public string Role { get; set; }
    }
}


