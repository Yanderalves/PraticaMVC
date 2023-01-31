using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Models;
using System.Diagnostics;

namespace SiteMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HomeModel model = new HomeModel();

            model.Nome = "Alves";
            model.Email = "Cerrisete@gmail.com";

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}