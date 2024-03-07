using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Interativa.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
