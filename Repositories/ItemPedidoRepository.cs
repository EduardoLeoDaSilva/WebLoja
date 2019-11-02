using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context.Set<ItemPedido>())
        {

        }
    }
}
