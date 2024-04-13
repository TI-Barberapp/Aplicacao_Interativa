using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Enums;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Aplicacao_Interativa.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(ISessao sessao, IEmail email, IUsuarioRepositorio usuarioRepositorio)
        {
            _sessao = sessao;
            _email = email;
            _usuarioRepositorio = usuarioRepositorio;
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

            return RedirectToAction("Index", "ClienteDeslogado");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Email);

                    if (usuario != null && usuario.SenhaValida(loginModel.Senha))
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
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EsqueciSenha(EsqueciSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(redefinirSenhaModel.Email);

                    if (usuario != null)
                    {
                        var urlConfirmacao = Url.Action("RedefinirSenha", "Login", new { id = usuario.Id }, protocol: HttpContext.Request.Scheme);


                        var mensagem = new StringBuilder();

                        mensagem.Append($"<p>Olá {usuario.Nome}.</p>");
                        mensagem.Append($"<p>Clique <a href='{urlConfirmacao}'>aqui</a> para redefinir sua senha.</p>");

                        _email.Enviar(usuario.Email, "Redefinir Senha", mensagem.ToString());
                        return RedirectToAction("Index", "Login");
                    }                     
                }

                return RedirectToAction("EsqueciSenha", "Login");
            }
            catch (Exception)
            {
                return RedirectToAction("EsqueciSenha", "Login");
            }
        }

        [HttpGet]
        public IActionResult RedefinirSenha(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.RecuperarPeloId(id);

            if (usuario == null)
            {
                id = -1;
            }

            var model = new RedefinirSenhaModel() { Usuario = id };

            return View(model);
        }

        [HttpPost]
        public IActionResult RedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("RedefinirSenha", "Login");
                }

                UsuarioModel usuario = _usuarioRepositorio.RecuperarPeloId(redefinirSenhaModel.Usuario);

                if (usuario != null)
                {
                    _usuarioRepositorio.SalvarNovaSenha(usuario, redefinirSenhaModel.NovaSenha);

                    return RedirectToAction("Index", "Login");
                }

                return RedirectToAction("RedefinirSenha", "Login");

            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }            
        }
    }
}
