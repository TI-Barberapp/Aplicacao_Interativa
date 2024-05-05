using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoVinculoAgendamentosAvaliacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avalicoes_Agendamentos_AgendamentoId",
                table: "Avalicoes");

            migrationBuilder.DropIndex(
                name: "IX_Avalicoes_AgendamentoId",
                table: "Avalicoes");

            migrationBuilder.DropColumn(
                name: "AgendamentoId",
                table: "Avalicoes");
        }
    }
}
