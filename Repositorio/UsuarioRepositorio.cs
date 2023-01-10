using SiteMVC.Data;
using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext context)
        {
            _context = context;
        }

        public List<UsuarioModel> ListarContatos()
        {
            List<UsuarioModel> usuario = _context.Usuarios.ToList();

            return usuario;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            if (usuario != null)
            {
                usuario.DataCadastro = DateTime.Now;    
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }

            return usuario;
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuario = BuscarUsuario(id);
            if(usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioBanco = BuscarUsuario(usuario.Id);

            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Perfil = usuario.Perfil;
            usuarioBanco.Login = usuario.Login;
            usuarioBanco.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();

            return usuarioBanco;
        }

        public UsuarioModel BuscarUsuario(int id)
        {
            UsuarioModel usuario = _context.Usuarios.Find(id);
            return usuario;
        }
    }
}
