using System.ComponentModel.DataAnnotations;

namespace Aplicacao_Interativa.Models
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        [Required]
        public int Avaliacao { get; set; }
        public int AgendamentoId { get; set; }
        public AgendamentoModel? Agendamento { get; set; }

    }
}
