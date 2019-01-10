using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class CityRepository : Repository<City>, ICity
    {
        public CityRepository(UspDbContext dbContext) : base(dbContext) { }
    }
}