using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaSuperMercado.Migrations
{
    public partial class produtoItemPedidoRelCorrigido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_ItemPedido_ItemPedidoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ItemPedidoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ItemPedidoId",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ItemPedido",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Produto_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_ProdutoId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItemPedido");

            migrationBuilder.AddColumn<int>(
                name: "ItemPedidoId",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ItemPedidoId",
                table: "Produto",
                column: "ItemPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_ItemPedido_ItemPedidoId",
                table: "Produto",
                column: "ItemPedidoId",
                principalTable: "ItemPedido",
                principalColumn: "ItemPedidoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
