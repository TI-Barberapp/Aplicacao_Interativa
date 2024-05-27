using System.Text;

namespace Aplicacao_Interativa.Models
{
    public class AgendamentoViewModel
    {
        public string NomeUsuario { get; set; }
        public string NomeBarbeiro { get; set; }
        public string NomeServico { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Horario { get; set; }
        public StringBuilder Produto { get; set; }
    }
}
