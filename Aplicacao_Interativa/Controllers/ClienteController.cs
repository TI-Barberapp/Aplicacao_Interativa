using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Filters;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Aplicacao_Interativa.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ClienteController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio)
        {

            _agendamentoRepositorio = agendamentoRepositorio;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
           return View();
        }

        public IActionResult Agendar()
        {
            List<UsuarioModel> barbeiros = _usuarioRepositorio.BuscarBarbeiros();
            ViewBag.Barbeiros = new SelectList(barbeiros, "Id", "Nome");

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

                    if (usuarioId != null)
                    {
                        agendamento.usuarioID = usuarioId.Value;
                        agendamento = _agendamentoRepositorio.Adicionar(agendamento);

                        TempData["MensagemSucesso"] = "O agendamento foi feito com sucesso";
                        return RedirectToAction("Index", "Cliente");
                    }                    
                }
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        // Concatene os erros de validação do ModelState em uma única string
                        TempData["MensagemErro"] += error.ErrorMessage + " ";
                    }
                }

                // Redirecionar de volta para a view para corrigir os erros
                return RedirectToAction("Index", "Cliente");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o agendamento. Detalhes: {erro.Message}";
                return RedirectToAction("Index", "Cliente");
            }
        }
    }
}
