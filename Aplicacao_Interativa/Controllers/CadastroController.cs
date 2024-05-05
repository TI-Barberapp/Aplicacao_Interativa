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
        private readonly ISessao _sessao;

        public CadastroController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            var usuarioModel = new UsuarioModel();

            var usuarioLogado = _sessao.BuscarSessaoUsuario();

            if (usuarioLogado != null && usuarioLogado.Perfil == Enums.PerfilEnum.Barbeiro)
            {
                usuarioModel.Perfil = usuarioLogado.Perfil;
            }
            else
            {
                usuarioModel.Perfil = Enums.PerfilEnum.Cliente;
            }

            return View(usuarioModel);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel email = _usuarioRepositorio.BuscarPorLogin(usuario.Email);
                    if (email == null)
                    {
                        usuario.SetGerarHash();
                        _usuarioRepositorio.Adicionar(usuario);
                        TempData["MensagemSucesso"] = "O cadastro foi feito com sucesso.";
                        return RedirectToAction("Index", "Login");
                    }
                    TempData["MensagemErro"] = "Esse e-mail já está sendo utilizado.";
                    return RedirectToAction("Criar", "Cadastro");
                }

                return RedirectToAction("Criar", "Cadastro");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o cadastro. Detalhes: {erro.Message}";
                return RedirectToAction("Criar", "Cadastro");
            }
        }
    }
}
