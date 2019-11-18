using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Newtonsoft.Json;
using Repositories;

namespace LojaSuperMercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        public PedidoController(ApplicationContext context, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            _context = context;
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult NovoPedido([FromBody]Produto produto, [FromHeader] Usuario usuario)
        {
            try
            {
                var email = ExtrairInformacoesToken();


                var user = _context.Set<Usuario>().Where(x => x.Email == email).SingleOrDefault();
                var pedido = _pedidoRepository.AddItemPedido(produto, user);
                _context.SaveChanges();
                var pedidoCompleto = _context.Set<Pedido>().Where(x => x.PedidoId == pedido.PedidoId).Include(x => x.ItemPedidos).ThenInclude(x => x.Produto).SingleOrDefault();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private string ExtrairInformacoesToken()
        {
            var tokenString = HttpContext.Request.Headers.Where(x => x.Key == "Authorization").SingleOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var somenteOToken = tokenString.Value.ToString().Replace("Bearer ", string.Empty);
            var token = tokenHandler.ReadJwtToken(somenteOToken);
            var claimEmail = token.Claims.ToList().Where( x=> x.Type == "email").SingleOrDefault();
            var usuarioEmail = claimEmail.Value;
            return usuarioEmail;
        }

        [Authorize]
        [HttpPost("Excluir")]
        public IActionResult ExcluirItemPedido([FromBody]ItemPedido itemPedido)
        {
            try
            {
                var itemPedidoBd = _context.Set<ItemPedido>().Where(x => x.ItemPedidoId == itemPedido.ItemPedidoId).SingleOrDefault();
                if (itemPedidoBd != null)
                {
                    _context.Set<ItemPedido>().Remove(itemPedidoBd);
                    _context.SaveChanges();
                }

                return Ok("Item Excluido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult ObterPedido()
        {
            try
            {
                var pedidoCompleto = _pedidoRepository.ObterPedidoCompleto();
                if (pedidoCompleto != null)
                {
                    return Ok(pedidoCompleto);
                }
                return Content("Ocorreu um erro!");
            }
            catch (Exception ex)
            {

                return BadRequest("Erro: " + ex);
            }
        }
        [Authorize]
        [HttpPost("AtualizarQuantidade")]
        public IActionResult AtualizarQuantidade(ItemPedido itemPedido)
        {
            try
            {
                var itemPedidoBd = _itemPedidoRepository.FindById(itemPedido.ItemPedidoId);
                if (itemPedido.Quantidade <= 0)
                {
                    _itemPedidoRepository.Excluir(itemPedidoBd);
                    _context.SaveChanges();
                    var pedidoCompleto = _pedidoRepository.ObterPedidoCompleto();
                    return Ok(pedidoCompleto);
                }
                else
                {
                    itemPedidoBd.Quantidade = itemPedido.Quantidade;
                    _itemPedidoRepository.Update(itemPedidoBd);
                    var pedidoCompleto = _pedidoRepository.ObterPedidoCompleto();
                    _context.SaveChanges();
                    return Ok(pedidoCompleto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro: " + ex.Message);
            }
        }

    }
}