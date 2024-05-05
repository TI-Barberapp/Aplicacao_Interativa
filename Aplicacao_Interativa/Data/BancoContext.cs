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
        public DbSet<HorarioModel> Horarios { get; set; }
        public DbSet<AvaliacaoModel> Avalicoes { get; set; }
		public DbSet<ImagemModel> Imagens { get; set; }

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

            //Inlcuir os horários no banco
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 1,
                Horario = "09:00"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 2,
                Horario = "09:50"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 3,
                Horario = "10:40"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 4,
                Horario = "11:30"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 5,
                Horario = "13:00"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 6,
                Horario = "14:40"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 7,
                Horario = "15:30"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 8,
                Horario = "16:20"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 9,
                Horario = "17:10"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 10,
                Horario = "18:00"
            });
            modelBuilder.Entity<HorarioModel>().HasData(new HorarioModel
            {
                Id = 11,
                Horario = "18:50"
            });
        }
    }
}
