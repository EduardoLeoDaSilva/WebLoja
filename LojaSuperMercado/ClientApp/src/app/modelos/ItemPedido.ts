import { Produto } from "./produto.modelo";
import { Pedido } from "./pedido";

export class ItemPedido{
    itemPedidoId: number;
    quantidade: number;
    preco: number;
    produto: Produto
    pedido: Pedido
}