using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class RequestRepo : Repository<Request>, IRequest
    {
        public RequestRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}