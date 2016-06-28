using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMVVM.Data
{
    public class DataContext: DbContext
    {

        public DataContext(): base("Default")//look for connection string "Default" from the base constructor
        {
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
