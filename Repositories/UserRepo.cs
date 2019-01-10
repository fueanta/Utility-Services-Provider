using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class UserRepo : Repository<User>, IUser
    {
        public UserRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}
