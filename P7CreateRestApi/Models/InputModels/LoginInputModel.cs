using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModels
{
    public class LoginInputModel
    {        
        public string UserName { get; set; }        
        public string Password { get; set; }
    }
}
