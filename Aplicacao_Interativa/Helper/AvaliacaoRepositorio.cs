using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Interativa.Helper
{
    public class AvaliacaoRepositorio : IAvalicaoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AvaliacaoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AvaliacaoModel Avaliar(AvaliacaoModel avaliacao)
        {
            _bancoContext.Avalicoes.Add(avaliacao);
            _bancoContext.SaveChanges();

            return avaliacao;
        }
        public List<AvaliacaoModel> BuscarAvaliacoesComRelacionamentos()
        {
            return _bancoContext.Avalicoes
                           .Include(a => a.Agendamento)
                               .ThenInclude(a => a.Usuario)
                           .ToList();
        }
    }
}
