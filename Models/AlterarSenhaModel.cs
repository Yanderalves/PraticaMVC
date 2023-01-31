using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digita a senha aí po")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digita a senha aí po")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Digita a senha aí po")]
        [Compare("NovaSenha", ErrorMessage = "Ih, as senhas não coincidem")]
        public string NovaSenhaConfirmacao { get; set; }


    }
}
