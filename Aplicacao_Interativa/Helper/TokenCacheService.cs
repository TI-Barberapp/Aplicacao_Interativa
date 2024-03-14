using Aplicacao_Interativa.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Aplicacao_Interativa.Helper
{
    public class TokenCacheService : ITokenCacheService
    {
        private readonly IMemoryCache _cache;
        public TokenCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }       

        public void SalvarTokenRedefinicaoSenha(int usuarioId, string token)
        {
            string chave = $"TokenRedefinicaoSenha_{usuarioId}";

            _cache.Set(chave, token, TimeSpan.FromHours(1));
        }

        public bool TokenEhValido(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            string chave = $"TokenRedefinicaoSenha_{token}";

            if (_cache.TryGetValue(chave, out string tokenCache))
            {
                return true;
            }

            return false;
        }
    }        
}
