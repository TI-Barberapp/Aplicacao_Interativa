using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacao_Interativa.Data.Map
{
	public class ImagemMap : IEntityTypeConfiguration<ImagemModel>
	{
		public void Configure(EntityTypeBuilder<ImagemModel> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Usuario);
		}
	}
}
