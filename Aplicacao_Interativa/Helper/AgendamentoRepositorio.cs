using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

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
        public List<AgendamentoModel> BuscarAgendamento()
        {
            return _bancoContext.Agendamentos.ToList();
        }
        public List<ProdutoModel> BuscarProdutos()
        {
            return _bancoContext.Produtos.ToList();
        }
        //Esse é um método para busca personalizada de agendamentos, baseado no barbeiro que está logado no sistema
        public List<AgendamentoModel> BuscarAgendamentosPeloNome(string nomeBarbeiro)
        {
            //Essa é a lista que reune todos os agendamentos
            List<AgendamentoModel> listaAgendamentos = BuscarAgendamento();
            List<AgendamentoModel> listaOrdenada = listaAgendamentos.OrderBy(a => a.HorarioId).ToList();
            //Essa é a lista com os agendamentos individuais, do barbeiro logado
            List<AgendamentoModel> listaDeAgendamentosPorBarbeiro = new List<AgendamentoModel>();

            foreach(AgendamentoModel agendamentos in listaOrdenada)
            {
                if (agendamentos.Barbeiro == nomeBarbeiro && agendamentos.DataAgendamento >= DateTime.Today)
                {  
                    listaDeAgendamentosPorBarbeiro.Add(agendamentos);
                }
            }
            return listaDeAgendamentosPorBarbeiro;
        }
        public List<ServicoModel> BuscarServicos()
        {
            return _bancoContext.Servicos.ToList();
        }
        public List<HorarioModel> BuscarHorarios()
        {
            return _bancoContext.Horarios.ToList();
        }
        public AgendamentoModel BuscarPorData(AgendamentoModel agendamento)
        {
            return _bancoContext.Agendamentos.FirstOrDefault(x =>x.DataAgendamento == agendamento.DataAgendamento &&x.HorarioId == agendamento.HorarioId &&x.Barbeiro == agendamento.Barbeiro);
        }
        public List<HorarioModel> BuscarHorariosDisponiveis(DateTime data)
        {
            var horariosDisponiveis = _bancoContext.Horarios.ToList();
            var agendamentosDoDia = _bancoContext.Agendamentos.Where(a => a.DataAgendamento.Date == data.Date).ToList();

            foreach (var agendamento in agendamentosDoDia)
            {
                horariosDisponiveis.RemoveAll(h => h.Id == agendamento.HorarioId);
            }
            return horariosDisponiveis;
        }
        public string BuscarServicoPeloId(int id)
        {
            List<ServicoModel> listaServicos = BuscarServicos();

            foreach (ServicoModel servicos in listaServicos)
            {
                if (servicos.Id == id)
                {
                    return servicos.Nome;
                }
            }
            return "serviço";
        }

        public string BuscarHorarioPeloId(int id)
        {
            List<HorarioModel> listaHorarios = BuscarHorarios();

            foreach (HorarioModel horario in listaHorarios)
            {
                if(horario.Id == id)
                {
                    return horario.Horario;
                }
            }

            return "00:00";
        }

        public StringBuilder BuscarProdutosPeloId(string produtoId)
        {
            List<ProdutoModel> produtos = BuscarProdutos();
            string[] vetorString = produtoId.Split(",").ToArray();
            StringBuilder produtosString = new StringBuilder();

            if (vetorString.Length <= 1)
                return produtosString;

            for (int i = 0; i < vetorString.Length; i++)
            {
                int vetorInt = int.Parse(vetorString[i]);

                foreach (ProdutoModel produto in produtos)
                {
                    if(produto.Id == vetorInt)
                    {
                        produtosString.Append($"{produto.Nome}, ");
                    }
                }
            }
            return produtosString;
        }

        

        public List<AgendamentoModel> BuscarAgendamentosPeloId(int id)
        {
            //Essa é a lista que reune todos os agendamentos
            List<AgendamentoModel> listaAgendamentos = BuscarAgendamento();
            List<AgendamentoModel> listaOrdenada = listaAgendamentos.OrderBy(a => a.DataAgendamento).ToList();
            //Essa é a lista com os agendamentos individuais, do barbeiro logado
            List<AgendamentoModel> listaDeAgendamentosPorBarbeiro = new List<AgendamentoModel>();

            foreach (AgendamentoModel agendamentos in listaOrdenada)
            {
                if (agendamentos.usuarioID == id)
                {
                    listaDeAgendamentosPorBarbeiro.Add(agendamentos);
                }
            }
            return listaDeAgendamentosPorBarbeiro;
        }

    }
}
