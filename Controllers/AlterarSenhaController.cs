using Microsoft.AspNetCore.Mvc;
using SiteMVC.Helper;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel sessaousuarioAtual = _sessao.BuscarSessao();

                    alterarSenhaModel.Id = sessaousuarioAtual.Id;

                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);

                    TempData["success"] = "Senha alterada com sucesso";
                }
            }
            catch (Exception)
            {
                TempData["error"] = "Login e/ou senha inválido(s)";
                throw;
            }
            return View("Index", alterarSenhaModel);
        }
    }
}
