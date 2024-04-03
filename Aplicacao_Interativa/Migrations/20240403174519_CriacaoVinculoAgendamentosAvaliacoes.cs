using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoVinculoAgendamentosAvaliacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendamentoId",
                table: "Avalicoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avalicoes_AgendamentoId",
                table: "Avalicoes",
                column: "AgendamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avalicoes_Agendamentos_AgendamentoId",
                table: "Avalicoes",
                column: "AgendamentoId",
                principalTable: "Agendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
