using Aplicacao_Interativa.Models;
using System.Text;

namespace Aplicacao_Interativa.Helper
{
    public interface IAgendamentoRepositorio
    {
        AgendamentoModel Adicionar(AgendamentoModel agendamentoModel);
        List<AgendamentoModel> BuscarAgendamento();
        List<AgendamentoModel> BuscarAgendamentosPeloNome(string nomeBarbeiro);
        List<ServicoModel> BuscarServicos();
        List<HorarioModel> BuscarHorarios();
        List<ProdutoModel> BuscarProdutos();
        AgendamentoModel BuscarPorData(AgendamentoModel agendamento);
        List<HorarioModel> BuscarHorariosDisponiveis(DateTime data);
        string BuscarServicoPeloId(int id);
        string BuscarHorarioPeloId(int id);
        List<AgendamentoModel> BuscarAgendamentosPeloId(int id);
        StringBuilder BuscarProdutosPeloId(string produtoId);
    }
}
