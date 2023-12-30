using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Store_Item
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public int Item_Id { get; set; }

        public virtual Item Item { get; set; }
        public int Store_Id { get; set; }

        public virtual Store Store { get; set; }
        public int Stock { get; set; }

    }
}
