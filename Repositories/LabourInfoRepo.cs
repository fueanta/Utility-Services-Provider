using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class LabourInfoRepo : Repository<LabourInfo>, ILabourInfo
    {
        public LabourInfoRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}