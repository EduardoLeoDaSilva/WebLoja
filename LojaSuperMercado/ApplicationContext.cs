using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaSuperMercado
{

    public class ApplicationContext: DbContext
    {

        public ApplicationContext(DbContextOptions options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //usuario e endereco
            modelBuilder.Entity<Usuario>().HasKey(x => x.UsuarioId);
            modelBuilder.Entity<Endereco>().HasKey(x => x.EnderecoId);
            modelBuilder.Entity<Usuario>().HasMany(x => x.Enderecos).WithOne(x => x.Usuario).IsRequired();
            /////

            ////Usuario e pedido
            modelBuilder.Entity<Pedido>().HasKey(x => x.PedidoId);
            modelBuilder.Entity<Usuario>().HasMany(x => x.Pedidos).WithOne(x => x.Usuario);


            ///Pedido e ItemPedido
            modelBuilder.Entity<ItemPedido>().HasKey(x => x.ItemPedidoId);
            modelBuilder.Entity<Pedido>().HasMany(x => x.ItemPedidos).WithOne(x => x.Pedido);

            /////ItemPedido e Produto
            ///
            modelBuilder.Entity<Produto>().HasKey(x => x.ProdutoId);
            modelBuilder.Entity<ItemPedido>().HasMany(x => x.Produtos);

        }
    }
}
