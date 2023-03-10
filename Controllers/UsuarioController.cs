using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio= usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.ListarContatos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["success"] = "Usuario criado com sucesso.";
                    _usuarioRepositorio.Adicionar(usuario);
                    return RedirectToAction("Index");
                }
                return View(usuario);

            }
            catch (Exception)
            {
                TempData["error"] = "Ih, deu alguma merda aí na hora de criar o usuario, irmão.";
                return View(usuario);
            }
        }

        public IActionResult PaginaEditar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        //[HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id     = usuarioSemSenha.Id,
                        Nome   = usuarioSemSenha.Nome,
                        Login  = usuarioSemSenha.Login,
                        Email  = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    TempData["success"] = "Usuario editado com sucesso.";
                    _usuarioRepositorio.Editar(usuario);
                    return RedirectToAction("Index");
                }
                return View("PaginaEditar", usuario);
            }
            catch (Exception)
            {
                TempData["error"] = "Mlk, deu alguma merda aí ao editar.";
                throw;
            }
        }

        public IActionResult ConfirmarDelecao(int id)
        {
            UsuarioModel contato = _usuarioRepositorio.BuscarUsuarioPorId(id);
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool deletado = _usuarioRepositorio.Deletar(id);
                if (deletado)
                {
                    TempData["success"] = "Usuario deletado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "KKKKKKKKKKKKKKKK Deu merda, o apagar foi de comes e bebes";
                }
            }
            catch (Exception)
            {
                TempData["error"] = "KKKKKKKKKKKKKKKK Deu merda, o apagar foi de comes e bebes";
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
