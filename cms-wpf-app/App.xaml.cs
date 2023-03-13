using cms_wpf_app.Core;
using cms_wpf_app.Services;
using cms_wpf_app.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace cms_wpf_app
{
    public partial class App : Application
    {

        private readonly ServiceProvider _serviceProvider;

        public App()
        {

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<CustomersViewModel>();
            services.AddSingleton<CreateViewModel>();

            services.AddSingleton<CreateOrderViewModel>();
            services.AddSingleton<OrdersViewModel>();
            services.AddSingleton<OrderDetailsViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();


            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
