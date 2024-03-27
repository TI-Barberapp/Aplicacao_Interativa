using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplicacao_Interativa.Migrations
{
    public partial class CriacaoTabelaHorarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Horario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "Id", "Horario" },
                values: new object[,]
                {
                    { 1, "09:00" },
                    { 2, "09:50" },
                    { 3, "10:40" },
                    { 4, "11:30" },
                    { 5, "13:00" },
                    { 6, "14:40" },
                    { 7, "15:30" },
                    { 8, "16:20" },
                    { 9, "17:10" },
                    { 10, "18:00" },
                    { 11, "18:50" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
