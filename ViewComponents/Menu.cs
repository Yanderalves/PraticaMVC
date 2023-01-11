using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteMVC.Models;

namespace SiteMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoString = HttpContext.Session.GetString("UsuarioLogado");

            if (String.IsNullOrEmpty(sessaoString) ){
                return null;
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoString); 
                return View(usuario);
            }
        }
    }
}
