using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace cms_wpf_app.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public static ObservableObject currentViewModel;


        [RelayCommand]
        private void OrdersView() => CurrentViewModel = new OrdersViewModel();

        [RelayCommand]
        private void CreateView() => CurrentViewModel = new CreateViewModel();


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
