using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ItemManager : Manager<Item>
    {
        public ItemManager(MyDbContext myDb) : base(myDb)
        {
        }
        public List<Item> Get()
        {
            var list = GetAll().ToList();
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public Item GetById(int id)
        {
            var Item =  GetAll().Where(i=>i.Id == id).FirstOrDefault();
            if (Item != null)
            {
                return Item;
            }
            else
                return null;
        }
        public void Add(Item item)
        {
            base.Add(item);
        }

        public bool Update(Item item)
        {
            var olditem = GetById(item.Id);
            if (olditem != null)
            {
                olditem.Name = item.Name;
                olditem.Price = item.Price;
                base.Update(olditem);
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                base.Delete(item);
                return true;
            }
            return false;
        }

    }
}
