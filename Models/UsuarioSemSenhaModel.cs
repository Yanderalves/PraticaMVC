using SiteMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário" )]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Escolha um Perfil pro usuário")]
        public EnumPerfil? Perfil { get; set; }
    }
}
