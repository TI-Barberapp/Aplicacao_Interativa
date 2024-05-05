using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
	public interface IImagemRepositorio
	{
		ImagemModel Adicionar(ImagemModel imagem);
		void Alterar(int usuarioId, string novoCaminho);
		List<ImagemModel> BuscarImagens();
		bool FotoUsuarioExistente(int id);
		string? ObterCaminhoImagemUsuarioLogado(int usuarioId);

    }
}
