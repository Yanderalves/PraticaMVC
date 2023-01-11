using SiteMVC.Models;

namespace SiteMVC.Helper
{
    public interface ISessao
    {
        public void CriarSessao(UsuarioModel usuario);
        public void RemoverSessao();
        public UsuarioModel BuscarSessao();
    }
}
