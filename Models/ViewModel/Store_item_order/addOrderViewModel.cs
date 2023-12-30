using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class addOrderViewModel
    {
        public int id { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public int ItemId { get; set; }

        public int StoreId { get; set; }

        public int Count { get; set; }

        public int Stock { get; set; } = 0;
    }
}
