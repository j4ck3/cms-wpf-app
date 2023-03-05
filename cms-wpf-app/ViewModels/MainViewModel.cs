using cms_wpf_app.Core;
using cms_wpf_app.Services;

namespace cms_wpf_app.ViewModels
{
    public partial class MainViewModel : ViewModel
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

        public RelayCommand NavigateToOrdersViewCommand { get; set; }
        public RelayCommand NavigateToCustomersViewCommand { get; set; }
        public RelayCommand NavigateToCreateCustomerViewCommand { get; set; }
        public RelayCommand NavigateToCreateOrderViewCommand { get; set; }
        public RelayCommand NavigateToOrderDetailsViewCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToOrdersViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OrdersViewModel>(); }, o => true);

            NavigateToCustomersViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CustomersViewModel>(); }, o => true);

            NavigateToCreateCustomerViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateViewModel>(); }, o => true);

            NavigateToCreateOrderViewCommand = new RelayCommand(o => { Navigation.NavigateTo<CreateOrderViewModel>(); }, o => true);

            NavigateToOrderDetailsViewCommand = new RelayCommand(o => { Navigation.NavigateTo<OrderDetailsViewModel>(); }, o => true);
        }
    }
}
