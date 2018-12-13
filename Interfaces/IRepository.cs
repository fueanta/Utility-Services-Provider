using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IArea : IRepository<Area>
    {
        IEnumerable<Area> GetAreasByCityId(int? cityId);
    }
    public interface ICity : IRepository<City> { }
    public interface IClient : IRepository<Client> { }
    public interface IEmployee : IRepository<Employee> { }
    public interface IUserLogin : IRepository<UserLogin> { }
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Insert(T ob);
        int Update(T ob);
        int Delete(T ob);
    }
}
