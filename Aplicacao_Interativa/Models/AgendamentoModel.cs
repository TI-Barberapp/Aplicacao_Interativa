namespace Aplicacao_Interativa.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; } = DateTime.Today;
        public string? Barbeiro { get; set; }
        public int usuarioID { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public int ServicoId { get; set; }
        public ServicoModel? Servico { get; set; }
        public int HorarioId { get; set; }
        public HorarioModel? Horario { get; set; }
        public string? ProdutoID { get; set; }
    }
}
