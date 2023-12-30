using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public int Stock {get; set; }
    }
}
