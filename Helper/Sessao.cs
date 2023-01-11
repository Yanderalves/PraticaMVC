using Newtonsoft.Json;
using SiteMVC.Models;
using System.Text.Json.Serialization;

namespace SiteMVC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;  
        }

        public UsuarioModel BuscarSessao()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("UsuarioLogado");

            if(String.IsNullOrEmpty(sessaoUsuario) ) {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            }
        }

        public void CriarSessao(UsuarioModel usuario)
        {
            string usuarioSerializado = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("UsuarioLogado", usuarioSerializado);
        }

        public void RemoverSessao()
        {
            _httpContext.HttpContext.Session.Remove("UsuarioLogado");
        }
    }
}
