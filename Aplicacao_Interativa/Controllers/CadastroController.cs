using Aplicacao_Interativa.Models;
using Aplicacao_Interativa.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao_Interativa.Controllers
{
    public class CadastroController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CadastroController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            _usuarioRepositorio.Adicionar(usuario);
            return RedirectToAction("Index");  
        }
    }
}
