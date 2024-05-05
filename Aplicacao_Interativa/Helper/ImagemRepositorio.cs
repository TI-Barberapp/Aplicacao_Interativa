using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
	public class ImagemRepositorio : IImagemRepositorio
	{
		private readonly BancoContext _bancoContext;

        public ImagemRepositorio(BancoContext bancoContext)
		{
			_bancoContext = bancoContext;
        }
		public ImagemModel Adicionar(ImagemModel imagem)
		{
			_bancoContext.Imagens.Add(imagem);
			_bancoContext.SaveChanges();

			return imagem;
		}

		public void Alterar(int usuarioId, string novoCaminho)
		{
			ImagemModel imagem = _bancoContext.Imagens.FirstOrDefault(imagem => imagem.UsuarioId == usuarioId);
			if (imagem != null)
			{
				imagem.CaminhoImgPerfil = novoCaminho;
				_bancoContext.SaveChanges();
			}
			else
			{
				throw new Exception("Imagem do usuário não encontrada para atualização.");
			}
		}

		public List<ImagemModel> BuscarImagens()
		{
			return _bancoContext.Imagens.ToList();
		}

		public bool FotoUsuarioExistente(int id)
		{
			return _bancoContext.Imagens.Any(imagem => imagem.UsuarioId == id);
		}

		public string? ObterImagemPorUsuarioId(int UsuarioId)
		{
			ImagemModel imagem = _bancoContext.Imagens.FirstOrDefault(imagem => imagem.UsuarioId == UsuarioId);

			if (imagem != null)
			{
				return imagem.CaminhoImgPerfil;
			}

			return null;
		}

        public string? ObterCaminhoImagemUsuarioLogado(int usuarioId)
        {
            ImagemModel imagem = _bancoContext.Imagens.FirstOrDefault(imagem => imagem.UsuarioId == usuarioId);

            if (imagem != null)
            {
				var caminhoImagemRepositorio = "/img/perfil/";
                var caminhoImagem = caminhoImagemRepositorio + imagem.CaminhoImgPerfil;

				return caminhoImagem;
            }
			
			return "/img/site/default-profile-image.png";
        }
    }
}
