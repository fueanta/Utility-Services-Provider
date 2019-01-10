using Models;
using System.Data.Entity;

namespace Data
{
    public class UspDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<LabourAssign> LabourAssigns { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfoes { get; set; }
        public DbSet<LabourInfo> LabourInfoes { get; set; }

        public UspDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
