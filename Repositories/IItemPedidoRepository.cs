using Modelos;

namespace Repositories
{
    public interface IItemPedidoRepository
    {
        void ExcluirItemPedido(ItemPedido itemPedido);
        void NovoItemPedido(Produto produto, Pedido pedido);
        void Update(ItemPedido e);
        ItemPedido FindById(int itemPedidoId);
        void Excluir(ItemPedido ent);
    }
}