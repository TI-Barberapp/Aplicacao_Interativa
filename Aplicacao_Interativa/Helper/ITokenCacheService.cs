using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface ITokenCacheService
    {
        void SalvarTokenRedefinicaoSenha(int usuarioId, string token);
        bool TokenEhValido(string token);
    }
}
