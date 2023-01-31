using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Editar(UsuarioModel contato);
        bool Deletar(int id);
        List<UsuarioModel> ListarContatos();
        UsuarioModel BuscarUsuarioPorId(int id);
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel AlterarSenha(AlterarSenhaModel usuario);
    }
}
