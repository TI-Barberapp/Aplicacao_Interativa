using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoVinculoAgendamentoHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {         
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Horarios_HorarioId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_HorarioId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Agendamentos");

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                table: "Agendamentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
