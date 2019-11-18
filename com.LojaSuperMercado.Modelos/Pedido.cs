using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Pedido
    {

        public Pedido()
        {

        }

        public Pedido( Usuario usuario, List<ItemPedido> itemPedidos)
        {
            Usuario = usuario;
            ItemPedidos = itemPedidos;
        }

        public Pedido(int pedidoId, Usuario usuario, List<ItemPedido> itemPedidos)
        {
            PedidoId = pedidoId;
            Usuario = usuario;
            ItemPedidos = itemPedidos;
        }

        public int PedidoId { get; set; }
        public Usuario  Usuario { get; set; }

        public List<ItemPedido> ItemPedidos { get; set; }
    }
}
