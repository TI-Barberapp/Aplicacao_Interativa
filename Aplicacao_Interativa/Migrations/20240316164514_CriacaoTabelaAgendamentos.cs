using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoTabelaAgendamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_usuarioID",
                table: "Agendamentos",
                column: "usuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Usuarios_usuarioID",
                table: "Agendamentos",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Usuarios_usuarioID",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_usuarioID",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Servico",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioModelId",
                table: "Agendamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioModelId",
                table: "Agendamentos",
                column: "UsuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Usuarios_UsuarioModelId",
                table: "Agendamentos",
                column: "UsuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
