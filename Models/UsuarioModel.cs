using SiteMVC.Helper;
using SiteMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Escolha um Perfil pro usuário")]
        public EnumPerfil? Perfil { get; set; }
        [Required(ErrorMessage = "Digite uma senha do usuário")]
        public string? Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataDelecao { get; set; }

        public virtual List<ContatoModel>? Contatos { get; set; }

        public bool ValidaSenha(string senha)
        {
            if (senha.GerarHash() == Senha)
                return true;
            return false;
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarSenhaNova()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

        public void SetNovaSenha(string senha)
        {
            Senha = senha.GerarHash();
        }
    }
}
