using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoVinculoImagensUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Imagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_UsuarioId",
                table: "Imagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Usuarios_UsuarioId",
                table: "Imagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Usuarios_UsuarioId",
                table: "Imagens");

            migrationBuilder.DropIndex(
                name: "IX_Imagens_UsuarioId",
                table: "Imagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Imagens");
        }
    }
}
