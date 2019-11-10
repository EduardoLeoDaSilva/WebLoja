using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaSuperMercado.Migrations
{
    public partial class RemovendoPropriedadeFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Produto",
                nullable: true);
        }
    }
}
