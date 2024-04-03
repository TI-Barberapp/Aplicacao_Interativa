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
        private readonly IAvalicaoRepositorio _avalicaoRepositorio;

        public ClienteController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio, IEmail email, IAvalicaoRepositorio avalicaoRepositorio)
        {

            _agendamentoRepositorio = agendamentoRepositorio;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
            _email = email;
            _avalicaoRepositorio = avalicaoRepositorio;
        }

        public IActionResult Index()
        {
            List<AvaliacaoModel> avaliacoes = _avalicaoRepositorio.BuscarAvaliacoesComRelacionamentos();
            ViewBag.Avaliacoes = avaliacoes;

            List<ServicoModel> servicos = _agendamentoRepositorio.BuscarServicos();
            ViewBag.Servicos = servicos;

            return View();
        }

        public IActionResult Avaliar(int agendamentoId)
        {
            ViewBag.agendamentoId = agendamentoId;

            return View();
        }

        public IActionResult Agendar(int servicoId)
        {
            var agendamento = new AgendamentoModel();

            List<UsuarioModel> barbeiros = _usuarioRepositorio.BuscarBarbeiros();
            ViewBag.Barbeiros = new SelectList(barbeiros, "Id", "Nome");            

            List<HorarioModel> horarios = _agendamentoRepositorio.BuscarHorarios();
            ViewBag.Horarios = horarios;

            ViewBag.ServicoId = servicoId;

            return View(agendamento);
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
                        var agendamentoExistente = _agendamentoRepositorio.BuscarPorData(agendamento.DataAgendamento, agendamento.HorarioId);

                        if (agendamentoExistente == null)
                        {
                            agendamento.usuarioID = usuarioId.Value;
                            agendamento = _agendamentoRepositorio.Adicionar(agendamento);


                            var mensagem = new StringBuilder();
                            mensagem.Append($"<p>Olá {usuarioLogado.Nome}.</p>");
                            mensagem.Append("<p> Seu agendemento ja foi marcado,obrigado pela preferência e te aguardamos em breve!</p>");

                            TempData["MensagemSucesso"] = "O agendamento foi feito com sucesso";
                            _email.Enviar(usuarioLogado.Email, "Confirmação de Agendamento", mensagem.ToString());

                            var agendamentoId = agendamento.Id;
                            return RedirectToAction("Avaliar", "Cliente", new {agendamentoId});
                        }
                        TempData["MensagemErro"] = $"O horário escolhido já possui agendamento.";
                        return RedirectToAction("Agendar", "Cliente");
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
        [HttpPost]
        public IActionResult Avaliar(AvaliacaoModel avaliacaoModel)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    avaliacaoModel = _avalicaoRepositorio.Avaliar(avaliacaoModel);
                    TempData["MensagemSucesso"] = "A avaliação foi enviada com sucesso.";
                    return RedirectToAction("Index", "Cliente");
                }
                TempData["MensagemErro"] = $"Não foi possível enviar o formulário de avalição.";
                return RedirectToAction("Avaliar", "Cliente"); 

            }catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar a avaliação. Detalhes: {erro.Message}";
                return RedirectToAction("Avaliar", "Cliente");
            }
        }
    }
}
