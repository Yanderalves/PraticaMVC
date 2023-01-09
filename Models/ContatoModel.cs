using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set;  }
        [Required(ErrorMessage = "Digite um Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite um email")]
        public  string Email { get; set; }
        [Required(ErrorMessage = "Digite um Telefone")]
        [Phone(ErrorMessage = "Digite um telefone válido")]
        public string Telefone { get; set; }
    }
}
