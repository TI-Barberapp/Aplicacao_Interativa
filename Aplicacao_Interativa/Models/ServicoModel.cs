using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao_Interativa.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }
        public string? CaminhoImagem { get; set; }
    }
}
