using Data;
using Entities;
using Interfaces;

namespace Repositories
{
    public class ClientRepository : Repository<Client>, IClient
    {
        public ClientRepository(DB_Context context) : base(context) { }
    }
}
