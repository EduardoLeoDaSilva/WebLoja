using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        private readonly ApplicationContext _context;
        public ItemPedidoRepository(ApplicationContext context) : base(context.Set<ItemPedido>())
        {
            _context = context;
        }

        public void NovoItemPedido(Produto produto, Pedido pedido)
        {
            var ProdjaExisteNoPed = false;
            if (pedido.ItemPedidos != null)
            ProdjaExisteNoPed =pedido.ItemPedidos.Where(x => x.Produto.CodigoProduto == produto.CodigoProduto).Any();

            var produtoBd = _context.Set<Produto>().Where(x => x.CodigoProduto == produto.CodigoProduto).SingleOrDefault();
            if (produtoBd != null && ProdjaExisteNoPed == false)
            {
                _dbSet.Add(new ItemPedido(0, pedido, 1, produto.Preco, produtoBd));
            }
        }

        public void ExcluirItemPedido(ItemPedido itemPedido)
        {
            Excluir(itemPedido);
        }

        public override void Update(ItemPedido e)
        {
            base.Update(e);
        }

        public ItemPedido FindById(int itemPedidoId)
        {
            var itemPedidoBd = _dbSet.Where(x => x.ItemPedidoId == itemPedidoId).SingleOrDefault();
            if(itemPedidoBd == null)
            {
                return null;
            }
            return itemPedidoBd;
        }

        public override void Excluir(ItemPedido ent)
        {
            base.Excluir(ent);
        }

    }
}
