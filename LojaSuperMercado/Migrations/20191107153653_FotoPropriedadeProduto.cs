using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaSuperMercado.Migrations
{
    public partial class FotoPropriedadeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Produto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Produto");
        }
    }
}
