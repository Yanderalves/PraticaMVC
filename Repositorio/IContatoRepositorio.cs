using SiteMVC.Models;

namespace SiteMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Editar(ContatoModel contato);
        bool Deletar(int id);
        List<ContatoModel> ListarContatos();

        ContatoModel BuscarContato(int id);
    }
}
