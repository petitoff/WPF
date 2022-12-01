﻿using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.ViewModel;

namespace WiredBrainCoffe
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();

            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
        }

        /// <summary>
        /// Method is executed when app is started
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
