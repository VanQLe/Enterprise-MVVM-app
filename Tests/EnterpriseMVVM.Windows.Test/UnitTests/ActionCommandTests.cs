using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMVVM.Windows.Test.UnitTests
{
    [TestClass]
    public class ActionCommandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionIfActionParameterIsNull()
        {
            var command = new ActionCommand(null);
        }

        [TestMethod]
        public void ExecuteInVokesAction()
        {
            var invoked = false;
            Action<Object> action = obj => invoked = true;

            var command = new ActionCommand(action);
            command.Execute();
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void ExecuteOverloadInvokesActionWithParameter()
        {

            var invoked = false;
            Action<Object> action = obj =>
                                        {
                                            Assert.IsNotNull(obj);
                                            invoked = true;
                                        };

            var command = new ActionCommand(action);
            command.Execute(new object());
            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void CanExecuteIsTrueByDefault()
        {
            var command = new ActionCommand(obj => { });
            Assert.IsTrue(command.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteOverloadExcutesTruePredicate()
        {
            var command = new ActionCommand(obj => { }, obj => (int)obj == 1);

            Assert.IsTrue(command.CanExecute(1));


        }
        
        [TestMethod]
        public void CanExecuteOverloadExecutesFalsePredicate()
        {
            var command = new ActionCommand(obj => { }, obj => (int)obj == 1);

            Assert.IsFalse(command.CanExecute(0));
        }









    }
}
