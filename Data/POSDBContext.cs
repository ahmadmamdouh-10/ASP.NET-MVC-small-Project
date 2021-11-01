using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class POSDBContext: DbContext
    {

        public POSDBContext():base("name=POSDB")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> tokens { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
