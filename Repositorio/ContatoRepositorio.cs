using SiteMVC.Data;
using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext context)
        {
            _context = context;
        }

        public List<ContatoModel> ListarContatos()
        {
            List<ContatoModel> contatos = _context.Contatos.ToList();

            return contatos;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            if (contato != null)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
            }

            return contato;
        }

        public bool Deletar(int id)
        {
            ContatoModel contato = _context.Contatos.FirstOrDefault(x => x.Id == id);
            if(contato != null)
            {
                _context.Contatos.Remove(contato);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoBanco = BuscarContato(contato.Id);
            contatoBanco.Email = contato.Email;
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return contatoBanco;
        }

        public ContatoModel BuscarContato(int id)
        {
            ContatoModel contato = _context.Contatos.Find(id);
            return contato;
        }
    }
}
