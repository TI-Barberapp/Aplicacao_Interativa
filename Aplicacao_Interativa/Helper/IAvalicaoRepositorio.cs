using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface IAvalicaoRepositorio
    {
        AvaliacaoModel Avaliar(AvaliacaoModel avaliacao);
        List<AvaliacaoModel> BuscarAvaliacoesComRelacionamentos();
    }
}
