using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Manager<T> where T : class
    {
        private readonly MyDbContext myDb;
        private readonly DbSet<T> mySet;

        public Manager(MyDbContext myDb)
        {
            this.myDb = myDb;
            this.mySet =  this.myDb.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return mySet;
        }

        public void Add(T item)
        {
            mySet.Add(item);
        }

        public void Update(T item)
        {
            mySet.Update(item);
        }

        public void Delete(T item)
        {
            mySet.Remove(item);
        }
    }
}
