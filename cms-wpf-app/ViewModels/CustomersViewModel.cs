using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CustomersViewModel : Core.ViewModel
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
        public Core.RelayCommand CreateCustomerViewCommand { get; set; }

        [ObservableProperty]
        private string pageTitle = "Customers";

        private DbService dbService;

        [ObservableProperty]
        public List<CustomerEntity> customers;

        public CustomersViewModel(INavigationService navigationService)
        {
            dbService = new DbService();
            GetAllCustomersAsync();

            Navigation = navigationService;
            CreateCustomerViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<CreateViewModel>(); }, o => true);

        }

        private async Task<List<CustomerEntity>> GetAllCustomersAsync()
        {
            Customers = await dbService.GetCustomersAsync();
            return Customers;
        }
    }
}
