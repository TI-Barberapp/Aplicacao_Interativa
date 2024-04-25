using Aplicacao_Interativa.Filters;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aplicacao_Interativa.Controllers
{
    [PaginaParaUsuarioLogado]
    public class BarbeiroController : Controller
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BarbeiroController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            var barbeiroLogado = _sessao.BuscarSessaoUsuario();
            List<AgendamentoModel> agendamentos = _agendamentoRepositorio.BuscarAgendamentosPeloNome(barbeiroLogado.Nome); 
            
            List<AgendamentoViewModel> viewModel = new List<AgendamentoViewModel>();

            foreach(var agendamento in agendamentos)
            {
                var nomeUsuario = _usuarioRepositorio.BuscarNomeUsuarioPeloId(agendamento.usuarioID);
                var nomeSevico = _agendamentoRepositorio.BuscarServicoPeloId(agendamento.ServicoId);
                var horario = _agendamentoRepositorio.BuscarHorarioPeloId(agendamento.HorarioId);

                viewModel.Add(new AgendamentoViewModel
                {
                    NomeUsuario = nomeUsuario,
                    NomeServico = nomeSevico,
                    DataAgendamento = agendamento.DataAgendamento,
                    Horario = horario
                });
            }

            ViewBag.Agendamentos = viewModel;

            return View();
        }
    }
}
