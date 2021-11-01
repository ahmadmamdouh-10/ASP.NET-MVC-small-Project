using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ModelRepository<T>: IModelRepository<T> where T : BaseModel
    {
        DbContext Context;
        DbSet<T> Table;
        public ModelRepository(IDBContextFactory _Factory)
        {
            Context = _Factory.GetContext();
            Table = Context.Set<T>();
        }
        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void Edit(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
        public T Get(int ID)
        {
            return
            Table.FirstOrDefault(i => i.ID == ID);
        }
        public IQueryable<T> Get()
        {
            return Table;
        }
    }
}
