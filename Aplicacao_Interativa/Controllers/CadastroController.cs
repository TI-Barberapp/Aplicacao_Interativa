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
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CadastroController(IUsuarioRepositorio usuarioRepositorio)
        {
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

                TempData["MensagemErro"] = "O cadastro não pôde ser realizado devido a erros no formulário.";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o cadastro. Detalhes: {erro.Message}";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
