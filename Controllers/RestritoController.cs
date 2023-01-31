using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;

namespace SiteMVC.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
