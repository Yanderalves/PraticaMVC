using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;

namespace SiteMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(loginModel.Login == "teste" && loginModel.Senha == "123")
                        return RedirectToAction("Index", "Home");
                    TempData["error"] = "Login e/ou senha inválido(s)";
                }
                return View("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
