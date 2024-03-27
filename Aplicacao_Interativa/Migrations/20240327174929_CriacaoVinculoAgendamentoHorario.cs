using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoVinculoAgendamentoHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_HorarioId",
                table: "Agendamentos",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Horarios_HorarioId",
                table: "Agendamentos",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
