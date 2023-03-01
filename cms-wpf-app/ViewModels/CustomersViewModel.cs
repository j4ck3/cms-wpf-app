using cms_wpf_app.Models;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CustomersViewModel : ObservableObject 
    {
        private DbService dbService;

        [ObservableProperty]
        private string pagetitle = "Customers";


        [ObservableProperty]
        public List<CustomerModel> customers;

        public  CustomersViewModel()
        {
            dbService = new DbService();
            GetAllCustomers();
        }

        private async Task<List<CustomerModel>> GetAllCustomers()
        {
            return customers = await dbService.GetCustomers();
        }
    }
}
