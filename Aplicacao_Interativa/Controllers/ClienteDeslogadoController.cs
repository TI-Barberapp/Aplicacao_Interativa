using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;


namespace Aplicacao_Interativa.Controllers
{
    public class ClienteDeslogadoController : Controller
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEmail _email;
        private readonly IAvalicaoRepositorio _avalicaoRepositorio;

        public ClienteDeslogadoController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio, IEmail email, IAvalicaoRepositorio avalicaoRepositorio)
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

    }
}
