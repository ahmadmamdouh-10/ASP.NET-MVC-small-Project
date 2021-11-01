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
    public class UnitOfWork
        : IUnitOfWork
    {
        DbContext Context;
        IModelRepository<User> UserRepo;
        IModelRepository<Token> TokenRepo;

        public UnitOfWork(IDBContextFactory _Factory,
            IModelRepository<User> _UserRepo, IModelRepository<Token> _TokenRepo)
        {
            Context = _Factory.GetContext();
            UserRepo = _UserRepo;
            TokenRepo = _TokenRepo;
        }

        public IModelRepository<User> GetUserRepo()
        {
            return UserRepo;
        }

        public IModelRepository<Token> GetTokenRepo()
        {
            return TokenRepo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
