using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Editar(UsuarioModel contato);
        bool Deletar(int id);
        List<UsuarioModel> ListarContatos();
        UsuarioModel BuscarUsuarioPorId(int id);
        UsuarioModel BuscarPorLogin(string login);
    }
}
