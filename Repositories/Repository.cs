using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Data;
using Interfaces;
using Models;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public UspDbContext Context;

        public Repository(UspDbContext dbContext)
        {
            Context = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public int Insert(T g)
        {
            Context.Set<T>().Add(g);
            return Context.SaveChanges();
        }

        public int Update(T g)
        {
            //Context.Entry(g).State = EntityState.Modified;
            Context.Set<T>().AddOrUpdate(g);
            return Context.SaveChanges();
        }

        public int Delete(T g)
        {
            Context.Set<T>().Remove(g);
            return Context.SaveChanges();
        }
    }
}
