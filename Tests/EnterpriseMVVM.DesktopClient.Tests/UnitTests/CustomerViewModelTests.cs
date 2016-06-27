using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMVVM.DesktopClient.Tests.UnitTests
{

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ViewModels;
    using Windows;
   
    
    [TestClass]
    public class CustomerViewModelTests
    {
      [TestMethod]
      public void IsViewModel()
        {
            Assert.IsTrue(typeof(CustomerViewModel).BaseType == typeof(ViewModel));
        }

        [TestMethod]
        public void ValidationErrorWhenCustomerNameExceed32Characters()
        {
            var viewModel = new CustomerViewModel
            {
               CustomerName = "1234567890abcd efghijkilmnopqrstv"
            };

            Assert.IsNotNull(viewModel["CustomerName"]);
        }

        [TestMethod]
        public void ValidationErrorWhenCustomerNameIsNotGreaterThanOrEqualTo2Characters()
        {
            var viewModel = new CustomerViewModel
            {
                CustomerName = "B"
            };

            Assert.IsNotNull(viewModel["CustomerName"]);
        }

        [TestMethod]
        public void NoValidationErrorWhenCustomerNameMeetsAllRequirements()
        {
            var viewModel = new CustomerViewModel
            {
                CustomerName = "David Anderson"
            };

            Assert.IsNull(viewModel["CustomerName"]);
        }

        [TestMethod]
        public void ValidationErrorWhenCustomerNameIsNotProvided()
        {
            var viewModel = new CustomerViewModel
            {
                CustomerName = null
            };

            Assert.IsNotNull(viewModel["CustomerName"]);
        }

    }
}