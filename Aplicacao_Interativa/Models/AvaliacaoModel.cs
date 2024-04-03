namespace Aplicacao_Interativa.Models
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public string Avaliacao { get; set; }
        public int AgendamentoId { get; set; }
        public AgendamentoModel? Agendamento { get; set; }

    }
}
