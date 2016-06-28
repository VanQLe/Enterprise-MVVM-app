using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMVVM.Data.Tests.FunctionalTests
{
    [TestClass]
    public class CustomerScenarioTests: FunctionalTest
    {
        [TestMethod]
        public void AddNewCustomerIsPersisted()//Persistence refer to the characteristic of state that outlive the process that created it.
        {
            //using (var dc = new DomainContext()) ;
            using (var bc = new BusinessContext())
            {
                // Customer entity = bc.AddNewCustomer("Van", "Le");
                //Assert.IsNotNull(entity);
                var customer = new Customer()
                {
                    Email = "van@gmail.com",
                    FirstName = "Van",
                    LastName = "Le"
                };
                bc.AddNewCustomer(customer);

                bool exists = bc.DataContext.Customers.Any(c => c.Id == customer.Id);
                Assert.IsTrue(exists);
            
            }
        }

    }
}
