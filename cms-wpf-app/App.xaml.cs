using cms_wpf_app.ViewModels;
using System.Windows;

namespace cms_wpf_app
{
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
