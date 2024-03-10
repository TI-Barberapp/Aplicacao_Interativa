using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao_Interativa.Controllers
{
    public class CadastroController : Controller
    {
        private readonly BancoContext _context;

        public CadastroController(BancoContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
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
