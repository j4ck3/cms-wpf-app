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

        [RelayCommand]
        private void CreateOrderView() => CurrentViewModel = new CreateOrderViewModel();


        public MainViewModel()
        {
            currentViewModel = new OrdersViewModel();
        }
    }
}
