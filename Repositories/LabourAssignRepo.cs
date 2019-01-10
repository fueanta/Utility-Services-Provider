using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class LabourAssignRepo : Repository<LabourAssign>, ILabourAssign
    {
        public LabourAssignRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}