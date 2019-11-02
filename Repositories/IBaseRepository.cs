using System.Collections.Generic;

namespace Repositories
{
    public interface IBaseRepository<E> where E : class
    {
        void Excluir(E ent);
        List<E> findAll();
        void Gravar(E e);
        void Update(E e);
    }
}