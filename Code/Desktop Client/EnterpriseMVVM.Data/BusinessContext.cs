using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMVVM.Data
{
    public sealed class BusinessContext : IDisposable //cant be inherited 
    {
        private readonly DataContext context;
        private bool disposed;
        public BusinessContext()
        {
            context = new DataContext();
        }
        
        public DataContext DataContext
        {
            get
            {
                return context;
            }
        }

        public void AddNewCustomer(Customer customer)
        {
            Check.Require(customer.Email);
            Check.Require(customer.FirstName);
            Check.Require(customer.LastName);

            context.Customers.Add(customer);
            context.SaveChanges();
        }

        static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                else if (value.Trim().Length == 0)
                    throw new ArgumentException();
            }
        }

        #region IDisposable Memebers
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting  unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose (bool disposing)
        {
            if(disposed || disposing)
            {
                return;
            }

            if (context != null)
            {
                context.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}
