using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class TransactionRepo : Repository<Transaction>, ITransaction
    {
        public TransactionRepo(UspDbContext dbContext) : base(dbContext) { }
    }
}