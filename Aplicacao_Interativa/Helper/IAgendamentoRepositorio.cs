using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface IAgendamentoRepositorio
    {
        AgendamentoModel Adicionar(AgendamentoModel agendamentoModel);
    }
}
