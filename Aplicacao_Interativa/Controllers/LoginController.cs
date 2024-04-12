﻿using Aplicacao_Interativa.Data;
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
        private readonly BancoContext _context;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(BancoContext context, ISessao sessao, IEmail email, IUsuarioRepositorio usuarioRepositorio)
        {
            _context = context;
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
                        TempData["MensagemSucesso"] = $"E-mail de redefinição de senha enviado com sucesso.";
                        return RedirectToAction("Index", "Login");
                    }
                     
                    TempData["MensagemErro"] = $"Não foi possível encontrar o e-mail informado.";
                }

                return RedirectToAction("EsqueciSenha", "Login");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível redefinir sua senha. Detalhes: {erro.Message}";
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

                if(usuario != null)
                {
                    usuario.Senha = redefinirSenhaModel.NovaSenha;

                    usuario.SetGerarHash();
                    _context.SaveChanges();

                    TempData["MensagemSucesso"] = "Senha redefinida com sucesso! Agora você já pode fazer login com a nova senha.";
                    return RedirectToAction("Index", "Login");
                }

                TempData["MensagemErro"] = "Usuário não encontrado.";
                return RedirectToAction("RedefinirSenha", "Login");

            }
            catch (Exception erro)
            {
                Console.WriteLine($"Não foi possível redefinir a senha. Erro: {erro.Message}");
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
