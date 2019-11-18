using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly ApplicationContext _context;
        public PedidoRepository(ApplicationContext context, IHttpContextAccessor httpContextAccessor, IItemPedidoRepository itemPedidoRepository) : base(context.Set<Pedido>())
        {
            _httpContextAccessor = httpContextAccessor;
            _itemPedidoRepository = itemPedidoRepository;
            _context = context;
        }


        private void SetPedidoSession(Pedido pedido)
        {
            _httpContextAccessor.HttpContext.Session.SetInt32("pedido", pedido.PedidoId);
        }

        private int? GetPedidoSession()
        {
            var pedidoId = _httpContextAccessor.HttpContext.Session.GetInt32("pedido");
            return pedidoId;
        }


        public Pedido AddItemPedido(Produto produto, Usuario usuario)
        {
            var pedido = _dbSet.Include(x => x.ItemPedidos).ThenInclude(x => x.Produto).ToList().Where(x => x.PedidoId == GetPedidoSession()).SingleOrDefault();
            if (pedido == null)
            {
                pedido = new Pedido(usuario, null);
                _dbSet.Add(pedido);
                _context.SaveChanges();
                SetPedidoSession(pedido);
            }
            _itemPedidoRepository.NovoItemPedido(produto, pedido);
            return pedido;
        }

        public void ExcluiritemPedido(int itemPedidoId)
        {
            var pedido = _dbSet.ToList().Where(x => x.PedidoId == GetPedidoSession()).SingleOrDefault();
            var itemPedido = _context.Set<ItemPedido>().Where(x => x.ItemPedidoId == itemPedidoId).SingleOrDefault();
            if (itemPedido != null)
            {
                _itemPedidoRepository.ExcluirItemPedido(itemPedido);
            }

        }

        public Pedido ObterPedidoCompleto()
        {
            var pedidoSession = _dbSet.ToList().Where(x => x.PedidoId == GetPedidoSession()).SingleOrDefault();
            if(pedidoSession != null)
            {
                var pedidoDb = _dbSet.Where(x => x.PedidoId == pedidoSession.PedidoId).Include(x => x.ItemPedidos).ThenInclude(x => x.Produto).SingleOrDefault();
                return pedidoDb;

            }
            return null;
        }



    }
}
