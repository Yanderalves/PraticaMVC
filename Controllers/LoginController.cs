using Microsoft.AspNetCore.Mvc;
using SiteMVC.Helper;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null && usuario.ValidaSenha(loginModel.Senha))
                    {
                        _sessao.CriarSessao(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["error"] = "Login e/ou senha inválido(s)";
                        return View("Index", loginModel);
                    }
                }
                return View("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult EnviarSenhaNova(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarSenhaNova();
                        string mensagem = $"Olá {usuario.Nome}, Tua nova senha é {novaSenha}";

                        _usuarioRepositorio.Editar(usuario);

                        _email.EnviarEmail(usuario.Email, "Sistema de contatos - Redefinição de senha", mensagem);
                        TempData["success"] = "Usuario encontrado. Senha enviada para o teu email cadastrado";
                    }
                    else
                    {
                        TempData["error"] = "Login e/ou senha inválido(s)";
                        return View("RedefinirSenha");
                    }
                }
                return View("Index");
            }
            catch (Exception)
            {
                TempData["error"] = "Login e/ou senha inválido(s)";
                throw;
            }
        }
    }
}
