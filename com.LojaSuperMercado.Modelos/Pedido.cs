using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Pedido
    {
        public int PeididoId { get; set; }
        public Usuario  Usuario { get; set; }

        public List<ItemPedido> Pedidos { get; set; }
    }
}
