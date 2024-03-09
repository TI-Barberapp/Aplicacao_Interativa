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
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "O cadastro foi feito com sucesso";
                    return RedirectToAction("Index", "Home");
                }

                return View("Index", "Home");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o cadastro. Detalhes: {erro.Message}";
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}
