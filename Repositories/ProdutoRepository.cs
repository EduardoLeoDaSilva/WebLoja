using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>
    {

        public ProdutoRepository(ApplicationContext context) : base(context.Set<Produto>())
        {

        }
    }
}
