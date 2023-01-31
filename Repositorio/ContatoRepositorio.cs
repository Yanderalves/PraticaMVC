using SiteMVC.Data;
using SiteMVC.Helper;
using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        private readonly ISessao _sessao;
        public ContatoRepositorio(BancoContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        public List<ContatoModel> ListarContatos(int usuarioId)
        {
            UsuarioModel usuarioAtual = _sessao.BuscarSessao();
            List<ContatoModel> contatos = _context.Contatos.Where(x => x.UsuarioId == usuarioAtual.Id).ToList();

            return contatos;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            UsuarioModel usuarioAtual = _sessao.BuscarSessao();
            contato.UsuarioId = usuarioAtual.Id;
            if (contato != null)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
            }

            return contato;
        }

        public bool Deletar(int id)
        {
            ContatoModel contato = BuscarContato(id);
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
            UsuarioModel usuarioAtual = _sessao.BuscarSessao();
            ContatoModel contatoBanco = BuscarContato(contato.Id);

            contatoBanco.Email = contato.Email;
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contato.UsuarioId = usuarioAtual.Id;

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
