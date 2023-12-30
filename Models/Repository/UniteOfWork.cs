using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UniteOfWork
    {
        public MyDbContext MyDbContext { get; set; }
        public UniteOfWork(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }
        public void Save()
        {
            MyDbContext.SaveChanges();
        }
    }
}
