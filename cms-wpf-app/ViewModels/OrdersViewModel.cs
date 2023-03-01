using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {

        [ObservableProperty]
        private string pageTitle = "Orders";

        private DbService dbService;

        [ObservableProperty]
        public List<OrderEntity> orders;


        public OrdersViewModel()
        {
            dbService = new DbService();
            GetAllOrders();
        }


        private async Task<List<OrderEntity>> GetAllOrders()
        {
            return Orders = await dbService.GetOrders();
        }
    }
}
