using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class AlteracaoTabelaServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Servicos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Servicos");
        }
    }
}
