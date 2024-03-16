﻿namespace Aplicacao_Interativa.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Horario { get; set; }
        public string Barbeiro { get; set; }
        public string Servico { get; set;}
        public int usuarioID { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
