namespace Aplicacao_Interativa.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public double Preco { get; set;}
        public string? CaminhoDaImagem { get; set; }
        public int? QntEstoque { get; set; }

    }
}
