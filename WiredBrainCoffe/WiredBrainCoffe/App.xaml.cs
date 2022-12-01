using System.Windows;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.ViewModel;

namespace WiredBrainCoffe
{
    public partial class App : Application
    {
        /// <summary>
        /// Method is executed when app is started
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow(new MainViewModel(new CustomersViewModel(new CustomerDataProvider()), new ProductsViewModel()));
            mainWindow.Show();
        }
    }
}
