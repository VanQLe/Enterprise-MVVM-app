using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMVVM.Windows.Tests.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Windows;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void IsAbstractBaseClass()
        {
            Type t = typeof(ViewModel);
            Assert.IsTrue(t.IsAbstract);
        }//end testMethod


        [TestMethod]
        public void IsIDataError()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSupported()
        {
            var viewModel = new StubViewModel();
            var value = viewModel.Error;
        }

        [TestMethod]
        public void IsObservableObject()
        {
            Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithInvalidValue()
        {
            var viewModel = new StubViewModel();
            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            var viewModel = new StubViewModel()
            {
                Requiredproperty = "Some Value"
            };

            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerReturnErrorMessageForRequestedInvalidProperty()
        {
            var viewModel = new StubViewModel
            {
                Requiredproperty = null,
                SomeOtherProperty = null

            };
            var msg = viewModel["SomeOtherProperty"];
            Assert.AreEqual("The SomeOtherProperty field is required.", msg);
        }

        class StubViewModel : ViewModel
        {
            [Required]
            public string Requiredproperty { get; set; }
            
            [Required]
            public string SomeOtherProperty { get; set; }
        }


    }//end class
}//end namespace
