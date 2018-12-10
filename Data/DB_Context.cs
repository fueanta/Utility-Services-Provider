using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB_Context : DbContext
    {
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }

        public DB_Context() : base("name=USP_DefaultConnection")
        {

        }
    }
}
