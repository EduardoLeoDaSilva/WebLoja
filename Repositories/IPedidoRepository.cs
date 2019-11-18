using Modelos;

namespace Repositories
{
    public interface IPedidoRepository
    {
        Pedido AddItemPedido(Produto produto, Usuario usuario);
        void ExcluiritemPedido(int itemPedidoId);

        Pedido ObterPedidoCompleto();
    }
}