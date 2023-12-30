using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class OrderExtaintion
    {
        public static Store_Item toModel(this addOrderViewModel viewModel)
        {
            return new Store_Item
            {
                DateTime = viewModel.DateTime,
                Item_Id = viewModel.ItemId,
                Store_Id = viewModel.StoreId,
                Stock = viewModel.Stock + viewModel.Count
            };
        }

        public static OrderViewModel toViewModel(this Store_Item order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ItemId = order.Item_Id,
                ItemName = order.Item.Name,
                StoreId = order.Store_Id,
                StoreName = order.Store.Name,
                Stock = order.Stock,
            };
        }

    }
}
