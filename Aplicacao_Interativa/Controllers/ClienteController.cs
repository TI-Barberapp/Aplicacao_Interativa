using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Filters;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace Aplicacao_Interativa.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEmail _email;

        public ClienteController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio, IEmail email)
        {

            _agendamentoRepositorio = agendamentoRepositorio;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
            _email = email;
        }

        public IActionResult Index()
        {           
            return View();
        }


        public IActionResult Agendar()
        {
            List<UsuarioModel> barbeiros = _usuarioRepositorio.BuscarBarbeiros();
            ViewBag.Barbeiros = new SelectList(barbeiros, "Id", "Nome");

            List<ServicoModel> servicos = _agendamentoRepositorio.BuscarServicos();
            ViewBag.Servicos = servicos;

            return View();
        }

        [HttpPost]
        public IActionResult Agendar(AgendamentoModel agendamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioId = _sessao.BuscarSessaoUsuarioId();

                    var usuarioLogado = _sessao.BuscarSessaoUsuario();

                    if (usuarioId != null)
                    {
                        agendamento.usuarioID = usuarioId.Value;
                        agendamento = _agendamentoRepositorio.Adicionar(agendamento);

                        var mensagem = new StringBuilder();
                        mensagem.Append($"<p>Olá {usuarioLogado.Nome}.</p>");
                        mensagem.Append("<p> Seu agendemento ja foi marcado,obrigado pela preferência e te aguardamos em breve!</p>");

                        TempData["MensagemSucesso"] = "O agendamento foi feito com sucesso";
                        _email.Enviar(usuarioLogado.Email, "Confirmação de Agendamento", mensagem.ToString());
                        return RedirectToAction("Index", "Cliente");
                    }
                }

                TempData["MensagemErro"] = $"Não foi possível realizar o agendamento.";
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o agendamento. Detalhes: {erro.Message}";
                return RedirectToAction("Index", "Cliente");
            }
        }
    }
}
