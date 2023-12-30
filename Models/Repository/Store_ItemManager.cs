using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repository
{
    public class Store_ItemManager : Manager<Store_Item>
    {
        public Store_ItemManager(MyDbContext myDb) : base(myDb)
        {
        }
        public List<OrderViewModel> Get()
        {
            var list = GetAll().Select(i=>i.toViewModel()).ToList();
            if(list == null)
            {
                return null;
            }
            return list;
        }
        public OrderViewModel GetOne(int store_Id, int item_Id)
        {
            var order = GetAll().Where(i=>i.Store_Id == store_Id && i.Item_Id == item_Id).FirstOrDefault();
            if(order == null)
            {
                return null;
            }
            return order.toViewModel();
        }
        public int GetStock(int store_Id , int item_Id)   //call from jquery request
        {
            var stock = GetAll().Where(i => i.Item_Id == item_Id && i.Store_Id == store_Id).FirstOrDefault();
            if (stock != null)
            {
                return stock.Stock;
            }
            return 0;
        }

        public void Add(addOrderViewModel viewModel)
        {
            base.Add(viewModel.toModel());
        }

        public void AddStock(addOrderViewModel viewModel)    // add new count on stock (purchase)
        {
            var order = GetAll().Where(i => i.Item_Id == viewModel.ItemId && i.Store_Id == viewModel.StoreId).FirstOrDefault();
            if(order != null)
            {
                order.Stock = order.Stock + viewModel.Count;
                base.Update(order);   
            }
            else
            {
                Add(viewModel);
            }

        }

        public void Sell(addOrderViewModel viewModel)
        {
            var order = GetAll().Where(i => i.Item_Id == viewModel.ItemId && i.Store_Id == viewModel.StoreId).FirstOrDefault();
            if (order != null)
            {
                if(order.Stock > viewModel.Count)
                {
                    order.Stock = order.Stock - viewModel.Count;
                }
                else
                {
                    order.Stock = 0;
                }
                base.Update(order);

            }
            else
            {
                Add(viewModel);
            }
        }
    }
}
