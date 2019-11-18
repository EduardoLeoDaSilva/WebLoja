import { Usuario } from "./usuario.modelo";
import { ItemPedido } from "./ItemPedido";

export class Pedido {

    pedidoId: number;
    usuario: Usuario;
    itemPedidos: Array<ItemPedido>
}