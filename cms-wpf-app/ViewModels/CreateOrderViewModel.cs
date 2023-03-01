using cms_wpf_app.Models;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CreateOrderViewModel : ObservableObject
    {
        //private static DataContext _context = new DataContext();

        [ObservableProperty]
        private string pageTitle = "Create an Issue";

        private DbService dbservice;

        public CreateOrderViewModel()
        {
            dbservice= new DbService();
        }

        [ObservableProperty]
        private string userName = null!;
        [ObservableProperty]
        private string orderMessage = null!;

        [RelayCommand]
        private async Task CreateOrder()
        {

            OrderModel order = new()
            {
                UserName = UserName,
                OrderMessage = OrderMessage,
            };

            await dbservice.SaveOrderToDb(order);
            ClearForm();
        }

        public void ClearForm()
        {
            UserName = string.Empty;
            OrderMessage = string.Empty;
        }
    }
}
