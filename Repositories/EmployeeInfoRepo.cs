using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class EmployeeInfoRepo : Repository<EmployeeInfo>, IEmployeeInfo
    {
        public EmployeeInfoRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}