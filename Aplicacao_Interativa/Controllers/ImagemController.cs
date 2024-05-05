using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao_Interativa.Controllers
{
    public class ImagemController : Controller
    {
        private string _caminhoServidor;
        private readonly ISessao _sessao;
        private readonly IImagemRepositorio _imagemRepositorio;

        public ImagemController(IWebHostEnvironment sistema, ISessao sessao, IImagemRepositorio imagemRepositorio)
        {
            _caminhoServidor = sistema.WebRootPath;
            _sessao = sessao;
            _imagemRepositorio = imagemRepositorio;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile foto)
        {
            try
            {
                if (foto == null || foto.Length == 0)
                {
                    ModelState.AddModelError("foto", "Por favor, selecione uma imagem.");
                    TempData["MensagemErro"] = "Por favor, selecione uma imagem.";
                    return RedirectToAction("Perfil", "Cliente");
                }

                var usuarioId = _sessao.BuscarSessaoUsuario().Id;

                string caminhoParaSalvarImagem = _caminhoServidor + "\\img\\perfil\\";
                string novoNomeParaImagem = $"{usuarioId}" + "_" + foto.FileName;
                string urlCompleta = caminhoParaSalvarImagem + novoNomeParaImagem;

                if (!_imagemRepositorio.FotoUsuarioExistente(usuarioId))
                {
                    if (!Directory.Exists(caminhoParaSalvarImagem))
                    {
                        Directory.CreateDirectory(caminhoParaSalvarImagem);
                    }

                    using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
                    {
                        foto.CopyToAsync(stream);
                    }

                    ImagemModel criarImagem = new ImagemModel
                    {
                        CaminhoImgPerfil = novoNomeParaImagem,
                        UsuarioId = usuarioId
                    };

                    _imagemRepositorio.Adicionar(criarImagem);

                    TempData["MensagemSucesso"] = "A foto foi adicionada com sucesso.";
                    return RedirectToAction("Perfil", "Cliente");
                }

                ImagemModel alterarImagem = new ImagemModel
                {
                    CaminhoImgPerfil = novoNomeParaImagem,
                    UsuarioId = usuarioId
                };

                using (var stream = System.IO.File.Create(caminhoParaSalvarImagem + novoNomeParaImagem))
                {
                    foto.CopyToAsync(stream);
                }

                _imagemRepositorio.Alterar(usuarioId, novoNomeParaImagem);

                TempData["MensagemSucesso"] = "A foto foi alterada com sucesso.";
                return RedirectToAction("Perfil", "Cliente");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar a foto. Detalhes: {ex.Message}";
                return RedirectToAction("Perfil", "Cliente");
            }
        }
    }
}
