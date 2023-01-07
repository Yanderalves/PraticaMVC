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

        public ContatoModel Adicionar(ContatoModel contato)
        {
            if (contato != null)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
            }

            return contato;
        }

        public ContatoModel Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            throw new NotImplementedException();
        }
    }
}
