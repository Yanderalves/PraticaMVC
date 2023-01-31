using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SiteMVC.Models;

namespace SiteMVC.Filters
{
    public class PaginaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string usuarioSessao = context.HttpContext.Session.GetString("UsuarioLogado");

            if (String.IsNullOrEmpty(usuarioSessao))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login"}, { "action", "Index"} });
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(usuarioSessao);

                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}
