using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoVinculoUsuarioAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "usuarioID",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "usuarioID",
                table: "Agendamentos");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Agendamentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Agendamentos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
