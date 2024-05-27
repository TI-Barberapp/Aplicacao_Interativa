using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Filters;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Http;
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
        private static List<string> ListaProdutos = new List<string>();
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEmail _email;
        private readonly IAvalicaoRepositorio _avalicaoRepositorio;
        private readonly IImagemRepositorio _imagemRepositorio;

        public ClienteController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio, IEmail email, IAvalicaoRepositorio avalicaoRepositorio, IImagemRepositorio imagemRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
            _email = email;
            _avalicaoRepositorio = avalicaoRepositorio;
            _imagemRepositorio = imagemRepositorio;
        }

        public IActionResult Index()
        {
            List<AvaliacaoModel> avaliacoes = _avalicaoRepositorio.BuscarAvaliacoesComRelacionamentos();
            ViewBag.Avaliacoes = avaliacoes;

            List<ServicoModel> servicos = _agendamentoRepositorio.BuscarServicos();
            ViewBag.Servicos = servicos;

            List<ImagemModel> imagens = _imagemRepositorio.BuscarImagens();
            ViewBag.Imagens = imagens;

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

            List<ProdutoModel> produtos = _agendamentoRepositorio.BuscarProdutos();
            ViewBag.Produtos = produtos;    

            ViewBag.ServicoId = servicoId;

            return View(agendamento);
        }

        public IActionResult Perfil()
        {
            var usuario = _sessao.BuscarSessaoUsuario();
            List<AgendamentoModel> agendamentos = _agendamentoRepositorio.BuscarAgendamentosPeloId(usuario.Id);

            List<AgendamentoViewModel> viewModel = new List<AgendamentoViewModel>();

            foreach (var agendamento in agendamentos)
            {
                var nomeSevico = _agendamentoRepositorio.BuscarServicoPeloId(agendamento.ServicoId);
                var horario = _agendamentoRepositorio.BuscarHorarioPeloId(agendamento.HorarioId);

                viewModel.Add(new AgendamentoViewModel
                {
                    NomeBarbeiro = agendamento.Barbeiro,
                    NomeServico = nomeSevico,
                    DataAgendamento = agendamento.DataAgendamento,
                    Horario = horario
                });
            }

            ViewBag.AgendamentosCliente = viewModel;

            var caminhoImagem = _imagemRepositorio.ObterCaminhoImagemUsuarioLogado(usuario.Id);
            ViewBag.Imagem = caminhoImagem; 

            return View(usuario);
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
                            string listaComoString = "";

                            if (ListaProdutos.Count > 1)
                            {
                                listaComoString = string.Join(",", ListaProdutos);
                            }
                            agendamento.ProdutoID = listaComoString;
                            agendamento = _agendamentoRepositorio.Adicionar(agendamento);
                            TempData["MensagemSucesso"] = "O agendamento foi feito com sucesso";
                            ListaProdutos.Clear();

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
                    return RedirectToAction("Index", "Cliente");
                }
                return RedirectToAction("Avaliar", "Cliente"); 

            }catch (Exception)
            {
                return RedirectToAction("Avaliar", "Cliente");
            }
        }
        
        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {
            try
            {
                var emailUsuario = _sessao.BuscarSessaoUsuario().Email;

                if (ModelState.IsValid)
                {
                    if (emailUsuario == usuario.Email)
                    {
                        _usuarioRepositorio.Atualizar(usuario);

                        TempData["MensagemSucesso"] = "Dados alterados com sucesso.";
                        return View("Perfil", usuario);
                    }

                    var emailExistente = _usuarioRepositorio.BuscarPorLogin(usuario.Email);
                    if (emailExistente == null)
                    {
                        _usuarioRepositorio.Atualizar(usuario);

                        TempData["MensagemSucesso"] = "Dados alterados com sucesso.";
                        return View("Perfil", usuario);
                    }

                    TempData["MensagemErro"] = $"Esse email já está sendo utilizado.";
                    return RedirectToAction("Perfil", "Cliente");
                }
                TempData["MensagemErro"] = $"Não foi possível atualizar os dados.";
                return RedirectToAction("Perfil", "Cliente");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar os dados. Detalhes: {erro.Message}";
                return RedirectToAction("Perfil", "Cliente");
            }
        }
        [HttpPost]
        public IActionResult Apagar(string senha)
        {
            try
            {
                UsuarioModel usuario = _sessao.BuscarSessaoUsuario();

                //Cria um usuário fake apenas para gerar a criptografia da senha
                UsuarioModel usuarioParaCriptografia = new UsuarioModel();
                string senhaCriptografada = _usuarioRepositorio.CriptografarSenha(usuarioParaCriptografia, senha);
                

                if (senhaCriptografada == usuario.Senha)
                {
                    _usuarioRepositorio.Apagar(usuario);
                    _sessao.RemoverSessaoUsuario();

                    return RedirectToAction("Index", "ClienteDeslogado");
                }

                TempData["MensagemErro"] = "Senha incorreta!";
                return RedirectToAction("Perfil", "Cliente");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível deletar o perfil. Detalhes: {erro.Message}";
                return RedirectToAction("Perfil", "Cliente");
            }
        }
        public IActionResult ArmazenarProdutoId(int ProdutoId)
        {
            string Id = ProdutoId.ToString();

            ListaProdutos.Add(Id);

            return new EmptyResult();
        }
    }
}
