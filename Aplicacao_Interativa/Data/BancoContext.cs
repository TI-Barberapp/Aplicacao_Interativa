using Aplicacao_Interativa.Data.Map;
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
        public DbSet<AgendamentoModel> Agendamentos { get; set; }
        public DbSet<ServicoModel> Servicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoMap());

            base.OnModelCreating(modelBuilder);

            //Incluir serviços ao banco
            modelBuilder.Entity<ServicoModel>().HasData(new ServicoModel
            {
                Id = 1,
                Nome = "Corte",
                Preco = 25
            });
            modelBuilder.Entity<ServicoModel>().HasData(new ServicoModel
            {
                Id = 2,
                Nome = "Barba",
                Preco = 15
            });
            modelBuilder.Entity<ServicoModel>().HasData(new ServicoModel
            {
                Id = 3,
                Nome = "Sobrancelha",
                Preco = 5
            });
            modelBuilder.Entity<ServicoModel>().HasData(new ServicoModel
            {
                Id = 4,
                Nome = "Corte + Sobrancelha",
                Preco = 30
            });
        }
    }
}
