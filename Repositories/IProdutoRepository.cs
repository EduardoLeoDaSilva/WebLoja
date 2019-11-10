using Modelos;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProdutoRepository
    {
        void GravarProdutosDeJson(string path);
        List<Produto> ObterTodos();
    }
}