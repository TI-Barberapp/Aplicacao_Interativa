using Aplicacao_Interativa.Enums;
using Aplicacao_Interativa.Helper;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao_Interativa.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Celular { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public PerfilEnum Perfil { get; set; }

        public virtual List<AgendamentoModel> Agendamentos { get; set; } = new List<AgendamentoModel>();


        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetGerarHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
