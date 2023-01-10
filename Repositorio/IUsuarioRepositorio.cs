using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel contato);
        UsuarioModel Editar(UsuarioModel contato);
        bool Deletar(int id);
        List<UsuarioModel> ListarContatos();
        UsuarioModel BuscarUsuario(int id);
    }
}
