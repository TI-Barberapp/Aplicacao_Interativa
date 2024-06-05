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
        private string _caminhoServidor;
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BarbeiroController(IWebHostEnvironment sistema, IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio)
        {
            _caminhoServidor = sistema.WebRootPath;
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
                var produtos = _agendamentoRepositorio.BuscarProdutosPeloId(agendamento.ProdutoID);

                viewModel.Add(new AgendamentoViewModel
                {
                    NomeUsuario = nomeUsuario,
                    NomeServico = nomeSevico,
                    DataAgendamento = agendamento.DataAgendamento,
                    Horario = horario,
                    Produto = produtos
                });
            }

            ViewBag.Agendamentos = viewModel;

            return View();
        }

        public IActionResult Produto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Produto(IFormFile imagem, ProdutoModel produto)
        {
            try
            {
                if (imagem == null || imagem.Length == 0)
                {
                    ModelState.AddModelError("foto", "Por favor, selecione uma imagem.");
                    TempData["MensagemErro"] = "Por favor, selecione uma imagem.";
                    return RedirectToAction("Produto", "Barbeiro");
                }

                //Essas são as Urls para salvar no sistema corretamente
                string caminhoParaSalvarImagem = _caminhoServidor + "\\img\\site\\";
                string urlCompleta = caminhoParaSalvarImagem + imagem.FileName;

                //Essa url é para ir para o BD, apenas como uma refência
                string urlBD = "/img/site/" + imagem.FileName;

                if (!Directory.Exists(caminhoParaSalvarImagem))
                {
                    Directory.CreateDirectory(caminhoParaSalvarImagem);
                }

                using (var stream = System.IO.File.Create(urlCompleta))
                {
                    imagem.CopyToAsync(stream);
                }

                produto.CaminhoDaImagem = urlBD;

                _agendamentoRepositorio.AdicionarProduto(produto);


                TempData["MensagemSucesso"] = "Produto inserido com sucesso.";
                return RedirectToAction("Produto", "Barbeiro");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível registrar o produto: {ex.Message}";
                return RedirectToAction("Produto", "Barbeiro");
            }
        }        
    }
}
