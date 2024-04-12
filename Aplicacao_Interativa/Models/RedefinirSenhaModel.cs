using System.ComponentModel.DataAnnotations;

namespace Aplicacao_Interativa.Models
{
    public class RedefinirSenhaModel
    {
        public int Usuario { get; set; }
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha.")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmarSenha { get; set; }
    }
}
