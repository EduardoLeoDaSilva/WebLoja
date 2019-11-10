using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaSuperMercado.Migrations
{
    public partial class CodigoPropriedadeProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoProduto",
                table: "Produto",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoProduto",
                table: "Produto");
        }
    }
}
