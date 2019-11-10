using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public int CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal Preco { get; set; }

    }
}
