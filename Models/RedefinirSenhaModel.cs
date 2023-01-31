using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Insira o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Insira o Email")]
        public string Email { get; set; }
    }
}
