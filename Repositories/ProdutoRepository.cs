using Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {

        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context) : base(context.Set<Produto>())
        {
            _context = context;
        }

        /// <summary>
        /// Grava os dados no banco verificando antes de salvar para não causar repetição de registros!
        /// </summary>
        /// <param name="path">Caminho do Arquivo json para fazer a descerialização para persistência</param>
        public void GravarProdutosDeJson(string path)
        {
            var textoJson = File.ReadAllText(path);
            var listaProdutos = JsonConvert.DeserializeObject<List<Produto>>(textoJson);
            var listaProdutosBd = _dbSet.ToList();
            if (listaProdutos.Count > 0)
            {
                foreach (var item in listaProdutos)
                {
                    if (!listaProdutosBd.Where(x => x.CodigoProduto == item.CodigoProduto).Any())
                    {
                        _dbSet.Add(item);
                    }
                }
                _context.SaveChanges();
            }
        }

        public List<Produto> ObterTodos()
        {
            var listaBd = _dbSet.ToList();

            if(listaBd.Count > 0)
            {
                return listaBd;
            }
            return null;
        }

    }
}
