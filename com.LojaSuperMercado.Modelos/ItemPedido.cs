using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class ItemPedido
    {


        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, int quantidade, decimal preco)
        {
            Pedido = pedido;
            Quantidade = quantidade;
            Preco = preco;
        }

        public ItemPedido(int itemPedidoId, Pedido pedido, int quantidade, decimal preco, Produto produto)
        {
            ItemPedidoId = itemPedidoId;
            Pedido = pedido;
            Quantidade = quantidade;
            Preco = preco;
            Produto = produto;
        }

        public int ItemPedidoId { get; set; }

        [JsonIgnore]
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public Produto Produto { get; set; }
    }
}
