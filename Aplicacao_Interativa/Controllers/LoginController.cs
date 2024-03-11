using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Interativa.Controllers
{
    public class LoginController : Controller
    {

        private readonly BancoContext _context;

        public LoginController(BancoContext context)
        {
            _context = context;
        }

        UsuarioModel BuscarPorLogin(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {               
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = BuscarPorLogin(loginModel.Email);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s).";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o login. Detalhes: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
