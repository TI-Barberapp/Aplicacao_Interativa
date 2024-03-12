using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Enums;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Interativa.Controllers
{
    public class LoginController : Controller
    {

        private readonly BancoContext _context;
        private readonly ISessao _sessao;

        public LoginController(BancoContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        UsuarioModel BuscarPorLogin(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public IActionResult Index()
        {
            //Se o usuário estiver logado retorna para a home
            var usuarioLogado = _sessao.BuscarSessaoUsuario();

            if (usuarioLogado != null)
            {
                if (usuarioLogado.Perfil == PerfilEnum.Barbeiro)
                {
                    return RedirectToAction("Index", "Barbeiro");
                }
                else if (usuarioLogado.Perfil == PerfilEnum.Cliente)
                {
                    return RedirectToAction("Index", "Cliente");
                }
            }

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoUsuario(usuario);

                            if (usuario.Perfil == PerfilEnum.Barbeiro)
                            {
                                return RedirectToAction("Index", "Barbeiro");
                            }
                            else if (usuario.Perfil == PerfilEnum.Cliente)
                            {
                                return RedirectToAction("Index", "Cliente");
                            }
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
