using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace cms_wpf_app.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public static ObservableObject currentViewModel = null!;


        [RelayCommand]
        private static void OrdersView() => currentViewModel = new OrdersViewModel();

        [RelayCommand]
        private static void CreateView() => currentViewModel = new CreateViewModel();


        public MainViewModel()
        {
            currentViewModel = new OrdersViewModel();
        }

        //[RelayCommand]
        //private static void GithubLink()
        //{
        //    Process.Start(new ProcessStartInfo
        //    {
        //        FileName = "https://github.com/j4ck3/address-book-wpf",
        //        UseShellExecute = true
        //    });
        //}
    }
}
