using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StoreManager : Manager<Store>
    {
        public StoreManager(MyDbContext myDb) : base(myDb)
        {
        }
        public List<Store> Get()
        {
            var list = GetAll().ToList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public Store GetById(int id)
        {
            var store = GetAll().Where(i => i.Id == id).FirstOrDefault();
            if (store != null)
            {
                return store;
            }
            else
                return null;
        }
        public void Add(Store store)
        {
            base.Add(store);
        }

        public bool Update(Store store)
        {
            var oldstore = GetById(store.Id);
            if (oldstore != null)
            {
                oldstore.Name = store.Name;
                oldstore.Address = store.Address;
                base.Update(oldstore);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var store = GetById(id);
            if (store != null)
            {
                base.Delete(store);
                return true;
            }
            return false;
        }
    }
}
