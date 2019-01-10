using Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Insert(T g);
        int Update(T g);
        int Delete(T g);
    }
}
