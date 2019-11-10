using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class BaseRepository<E> : IBaseRepository<E> where E : class
    {

        public  DbSet<E> _dbSet { get; private set; }

        public BaseRepository(DbSet<E> dbset)
        {
            this._dbSet = dbset;
        }

        public void Gravar(E e)
        {

            if (e != null)
            {
                _dbSet.Add(e);
                return;
            }
            throw new Exception("Erro ao tentar salvar");
        }

        public List<E> findAll()
        {
            var dadosBd = _dbSet.ToList();
            if (dadosBd.Count > 0)
            {
                return dadosBd;
            }
            else
            {
                return null;
            }
        }

        public void Update(E e)
        {

            if (e != null)
            {
                _dbSet.Update(e);
            }
            throw new Exception("Erro ao tentar atualizar!");

        }

        public void Excluir(E ent)
        {
            if (ent != null)
            {
                _dbSet.Remove(ent);
            }
            throw new Exception("Erro ao tentar Excluir");

        }

    }
}
