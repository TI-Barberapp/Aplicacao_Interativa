using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Aplicacao_Interativa.Helper
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AgendamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AgendamentoModel Adicionar(AgendamentoModel agendamento)
        {
            _bancoContext.Agendamentos.Add(agendamento);
            _bancoContext.SaveChanges();

            return agendamento;
        }
        public List<ServicoModel> BuscarServicos()
        {
            return _bancoContext.Servicos.ToList();
        }

    }
}
