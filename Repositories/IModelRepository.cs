using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IModelRepository<T>
    {
        void Add(T entity);

        void Edit(T entity);

        void Remove(T entity);
        T Get(int ID);
        IQueryable<T> Get();
    }
}
