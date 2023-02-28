using CommunityToolkit.Mvvm.ComponentModel;

namespace cms_wpf_app.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {

        [ObservableProperty]
        private string pageTitle = "Orders";
        public OrdersViewModel()
        {

        }
    }
}
