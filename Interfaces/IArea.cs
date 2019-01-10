using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IArea : IRepository<Area>
    {
        IEnumerable<Area> GetAreasByCityId(int? cityId);
    }
}