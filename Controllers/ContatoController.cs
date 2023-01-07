using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repositorio;

namespace SiteMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;   
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.ListarContatos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
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
            bool deletado = _contatoRepositorio.Deletar(id);
            if (deletado)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    } 
}
