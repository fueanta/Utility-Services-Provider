using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class ServiceRepo : Repository<Service>, IService
    {
        public ServiceRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}