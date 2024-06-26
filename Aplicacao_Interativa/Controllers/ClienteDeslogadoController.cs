﻿using Aplicacao_Interativa.Enums;
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
        private readonly IImagemRepositorio _imagemRepositorio;

        public ClienteDeslogadoController(IAgendamentoRepositorio agendamentoRepositorio, ISessao sessao, IUsuarioRepositorio usuarioRepositorio, IEmail email, IAvalicaoRepositorio avalicaoRepositorio, IImagemRepositorio imagemRepositorio)
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

    }
}
