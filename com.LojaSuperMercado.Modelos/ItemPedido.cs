using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public Produto Produto { get; set; }
    }
}
