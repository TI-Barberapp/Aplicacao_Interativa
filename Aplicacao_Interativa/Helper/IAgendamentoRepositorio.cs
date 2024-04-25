using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface IAgendamentoRepositorio
    {
        AgendamentoModel Adicionar(AgendamentoModel agendamentoModel);
        List<AgendamentoModel> BuscarAgendamento();
        List<AgendamentoModel> BuscarAgendamentosPeloNome(string nomeBarbeiro);
        List<ServicoModel> BuscarServicos();
        List<HorarioModel> BuscarHorarios();
        AgendamentoModel BuscarPorData(DateTime data, int horarioId);
        List<HorarioModel> BuscarHorariosDisponiveis(DateTime data);
        string BuscarServicoPeloId(int id);

        string BuscarHorarioPeloId(int id);
    }
}
