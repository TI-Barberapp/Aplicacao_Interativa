namespace Aplicacao_Interativa.Models
{
	public class ImagemModel
	{
		public int Id { get; set; }
		public string? CaminhoImgPerfil { get; set; }
		public int UsuarioId { get; set; }
		public UsuarioModel? Usuario { get; set; }
	}
}
