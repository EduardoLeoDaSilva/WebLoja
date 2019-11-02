using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class BaseRepository<E> where E : class
    {

        private readonly DbSet<E> _dbSet;

        public BaseRepository(DbSet<E> dbset)
        {
            this._dbSet = dbset;
        }

        public void Gravar(E e)
        {
            try
            {
                if(e != null)
                {
                    _dbSet.Add(e);
                    return;
                }
                throw new Exception("Erro ao tentar salvar");
            }
            catch (Exception err)
            {

                throw new Exception("Erro: "+ err.Message);
            }
        }

        public List<E> findAll()
        {
            var dadosBd = _dbSet.ToList();
            if(dadosBd.Count > 0)
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
            try
            {
                if(e != null)
                {
                _dbSet.Update(e);
                }
                throw new Exception("Erro ao tentar atualizar!");
            }
            catch (Exception err)
            {

                throw  new Exception($"Erro: {err.Message}");
            }
        }

        public void Excluir(E ent)
        {

            try
            {
                _dbSet.Remove(ent);
            }
            catch (Exception err)
            {

                throw new Exception("Erro: " + err.Message);
            }
        }

    }
}
