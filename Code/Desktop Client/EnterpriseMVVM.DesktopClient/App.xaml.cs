using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EnterpriseMVVM.DesktopClient.Views;


namespace EnterpriseMVVM.DesktopClient
{
    using ViewModels;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Overrides of Application
        /// <summary>
        /// Raises the <see cref ="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A<see cref="T:System.Windows.StartupEventArgs"/> that contain the event data. </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow
            {
                DataContext = new CustomerViewModel()
            };

            window.ShowDialog();
        }

        #endregion

    }
}
