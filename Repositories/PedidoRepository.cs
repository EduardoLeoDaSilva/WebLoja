using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(ApplicationContext context) : base(context.Set<Pedido>())
        {

        }
    }
}
