using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Insira o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira a senha")]
        public string Senha { get; set; }
    }
}
