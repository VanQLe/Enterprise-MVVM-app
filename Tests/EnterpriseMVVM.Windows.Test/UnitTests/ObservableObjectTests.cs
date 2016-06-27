using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Windows.Tests.UnitTests
{
    using EnterpriseMVVM.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void PropertyChangedEventHandlerIsRaised()
        {
            var obj = new StubObservableObject();
            bool raised = false;

            obj.PropertyChanged += (sender, e) =>
                                                {
                                                    Assert.IsTrue(e.PropertyName == "ChangedProperty");
                                                    raised = true;
                                                };

            obj.ChangedProperty = "Some Value";
            if (!raised)
            {
                Assert.Fail("PropertyChanged was never invoked");
            }

        }//end method


        class StubObservableObject : ObservableObject
        {
            private string changedProperty;

            public string ChangedProperty
            {
                get
                {
                    return changedProperty;
                }

                set
                {
                    changedProperty = value;
                    NotifyPropertyChanged();//dont need to pass in the parameter because the default value of the parameter for the method is an empty string.  At run time the compiler will pass the name of this property to the method as the parameter.
                }
            }
        }//end StubObervableObject class

         

    }//end ObservableObjectTests class
}//end namespace
