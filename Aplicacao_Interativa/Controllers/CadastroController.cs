using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Filters;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Interativa.Controllers
{
    public class CadastroController : Controller
    {
        private readonly BancoContext _context;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CadastroController(BancoContext context, IUsuarioRepositorio usuarioRepositorio)
        {
            _context = context;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            
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
                    usuario.SetGerarHash();
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "O cadastro foi feito com sucesso";
                    return RedirectToAction("Index", "Login");
                }

                return View("Index", "Login");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o cadastro. Detalhes: {erro.Message}";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
