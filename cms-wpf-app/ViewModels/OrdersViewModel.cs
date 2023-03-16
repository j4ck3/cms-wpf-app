using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace cms_wpf_app.ViewModels
{
    public partial class OrdersViewModel : Core.ViewModel
    {
        public INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public Core.RelayCommand NavigateToOrderDetailsViewCommand { get; set; }
        public Core.RelayCommand CreateOrderViewCommand { get; set; }

        [ObservableProperty]
        private string pageTitle = "Manage Orders";

        private DbService dbService;

        [ObservableProperty]
        private ObservableCollection<OrderEntity> orders;


        public OrdersViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToOrderDetailsViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<OrderDetailsViewModel>(); }, o => true);
            CreateOrderViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<CreateOrderViewModel>(); }, o => true);
            dbService = new DbService();
            GetAllOrders();
        }

        private async Task GetAllOrders()
        {
            Orders = await dbService.GetOrdersAsync();
        }
    }
}
