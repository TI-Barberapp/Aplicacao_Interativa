using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoTabelaAgendamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Serico",
                table: "Agendamentos",
                newName: "Servico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Servico",
                table: "Agendamentos",
                newName: "Serico");
        }
    }
}
