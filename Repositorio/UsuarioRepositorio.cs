using Microsoft.EntityFrameworkCore;
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
            List<UsuarioModel> usuario = _context.Usuarios.Include(x => x.Contatos).ToList();

            return usuario;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            if (usuario != null)
            {
                usuario.DataCadastro = DateTime.Now;
                usuario.SetSenhaHash();
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }

            return usuario;
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuario = BuscarUsuarioPorId(id);
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
            UsuarioModel usuarioBanco = BuscarUsuarioPorId(usuario.Id);

            usuarioBanco.Email = usuario.Email;
            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Perfil = usuario.Perfil;
            usuarioBanco.Login = usuario.Login;
            usuarioBanco.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();

            return usuarioBanco;
        }

        public UsuarioModel BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuario = _context.Usuarios.Find(id);
            return usuario;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.Login == login);
            return usuario;
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Login == login);
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel usuarioAlterarSenha)
        {
            UsuarioModel usuario = BuscarUsuarioPorId(usuarioAlterarSenha.Id);

            if (usuario == null) throw new Exception("Ih, usuário não encontrado");
            if (!usuario.ValidaSenha(usuarioAlterarSenha.SenhaAtual)) throw new Exception("Ih, senha atual incorreta");
            if (usuario.Senha == usuarioAlterarSenha.NovaSenha) throw new Exception("Ih, a nova senha há de ser distinta da senha atual");

            usuario.SetNovaSenha(usuarioAlterarSenha.NovaSenha);
            usuario.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
