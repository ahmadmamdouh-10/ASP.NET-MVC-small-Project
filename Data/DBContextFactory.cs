using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBContextFactory
        : IDBContextFactory
    {
        public readonly DbContext Context;

        public DBContextFactory()
        {
            Context = Context ?? new POSDBContext();
        }

        public DbContext GetContext()
        {
            return Context;
        }


    }
}
