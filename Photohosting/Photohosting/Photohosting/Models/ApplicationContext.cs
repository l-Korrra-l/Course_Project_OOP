using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photohosting.Models
{
    public partial class ApplicationContext : System.Data.Entity.DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Error> Errors { get; set; }
        public ApplicationContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
