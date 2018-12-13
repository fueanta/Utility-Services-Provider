using Data;
using Entities;
using Interfaces;
using System.Linq;

namespace Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployee
    {
        public EmployeeRepository(DB_Context context) : base(context) { }

        public override Employee Get(int id)
        {
            return Context.Set<Employee>().SingleOrDefault(e => e.FakeId == id);
        }

        public override int Delete(Employee g)
        {
            Context.Set<Employee>().Remove(Get(g.FakeId));
            return Context.SaveChanges();
        }
    }
}
