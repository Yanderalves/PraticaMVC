using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Helper;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;
        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioAtual = _sessao.BuscarSessao();
            List<ContatoModel> contatos = _contatoRepositorio.ListarContatos(usuarioAtual.Id);
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["success"] = "Contato criado com sucesso.";
                    _contatoRepositorio.Adicionar(contato);
                    return RedirectToAction("Index");
                }
                return View(contato);

            }
            catch (Exception)
            {
                TempData["error"] = "Ih, deu alguma merda aí na hora de criar o contato, irmão.";
                return View(contato);
            }

        }

        public IActionResult PaginaEditar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarContato(id);
            return View(contato);
        }

        //[HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["success"] = "Contato editado com sucesso.";
                    _contatoRepositorio.Editar(contato);
                    return RedirectToAction("Index");
                }
                return View("PaginaEditar", contato);
            }
            catch (Exception)
            {
                TempData["error"] = "Mlk, deu alguma merda aí ao editar.";
                throw;
            }

        }

        public IActionResult BuscarContato()
        {
            return View();
        }

        public IActionResult ConfirmarDelecao(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarContato(id);
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool deletado = _contatoRepositorio.Deletar(id);
                if (deletado)
                {
                    TempData["success"] = "Contato deletado com sucesso.";
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
