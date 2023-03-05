using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using cms_wpf_app.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class OrdersViewModel : ViewModel
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

        [ObservableProperty]
        private string pageTitle = "Orders";

        private DbService dbService;

        [ObservableProperty]
        private List<OrderEntity> orders;


        public OrdersViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToOrderDetailsViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<OrderDetailsViewModel>(); }, o => true);
            dbService = new DbService();
            GetAllOrders();
        }




        private async Task<List<OrderEntity>> GetAllOrders()
        {
            Orders = await dbService.GetOrdersAsync();
            return Orders;
        }
    }
}
