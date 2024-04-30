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

                    if (usuarioId != null)
                    {
                        var agendamentoExistente = _agendamentoRepositorio.BuscarPorData(agendamento);

                        if (agendamentoExistente == null)
                        { 
                            //Efetivação do agendamento e envio para o banco
                            agendamento.usuarioID = usuarioId.Value;
                            agendamento = _agendamentoRepositorio.Adicionar(agendamento);
                            TempData["MensagemSucesso"] = "O agendamento foi feito com sucesso";
                            

                            //Configuração dos componentes presentes no e-mail e envio do mesmo
                            var usuarioLogado = _sessao.BuscarSessaoUsuario();
                            var emailBarbeiro = _usuarioRepositorio.BuscarEmailBarbeiroEspecifico(agendamento.Barbeiro);
                            var nomeServico = _agendamentoRepositorio.BuscarServicoPeloId(agendamento.ServicoId);
                            var horarioServico = _agendamentoRepositorio.BuscarHorarioPeloId(agendamento.HorarioId);

                            var mensagem = new StringBuilder();
                            mensagem.Append($"<p>Olá {agendamento.Barbeiro}.</p>");
                            mensagem.Append($"<p> O cliente {usuarioLogado.Nome} marcou um/a {nomeServico} no dia {agendamento.DataAgendamento.ToShortDateString()} às {horarioServico} horas.</p>");

                            _email.Enviar(emailBarbeiro, "Confirmação de Agendamento", mensagem.ToString());

                            //Redirecionamento da página para a avaliação
                            var agendamentoId = agendamento.Id;
                            return RedirectToAction("Avaliar", "Cliente", new {agendamentoId});
                        }
                        TempData["MensagemErro"] = $"O horário escolhido já possui agendamento.";
                        return RedirectToAction("Agendar", "Cliente");
                    }
                }
                TempData["MensagemErro"] = $"Não foi possível realizar o agendamento.";
                return RedirectToAction("Agendar", "Cliente");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o agendamento. Detalhes: {erro.Message}";
                return RedirectToAction("Agendar", "Cliente");
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
