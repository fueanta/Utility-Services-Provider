using System.Collections.Generic;
using System.Linq;
using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class AreaRepository : Repository<Area>, IArea
    {
        public AreaRepository(UspDbContext dbContext) : base(dbContext) { }

        public IEnumerable<Area> GetAreasByCityId(int? cityId)
        {
            return Context.Set<Area>().Where(a => a.CityId == cityId).ToList();
        }
    }
}