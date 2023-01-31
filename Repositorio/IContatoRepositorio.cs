using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        bool Deletar(int id);
        List<ContatoModel> ListarContatos(int usuarioId);

        ContatoModel BuscarContato(int id);
    }
}
