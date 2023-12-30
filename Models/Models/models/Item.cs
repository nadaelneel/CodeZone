using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

       public decimal Price { get; set; }
        public virtual ICollection<Store_Item> Store_Items { get; set; }
    }
}
