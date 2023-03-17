using cms_wpf_app.Models;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels;

public partial class CreateOrderViewModel : Core.ViewModel
{

    [ObservableProperty]
    private string pageTitle = "Submit an Order";

    private DbService dbservice;

    public CreateOrderViewModel()
    {
        dbservice = new DbService();
    }

    [ObservableProperty]
    private string inputUserName;

    [ObservableProperty]
    private string inputOrderMessage;

    [ObservableProperty]
    private string submitOrderStatus;

    [RelayCommand]
    private async Task CreateOrder()
    {
        OrderModel order = new()
        {
            UserName = InputUserName,
            OrderMessage = InputOrderMessage
        };

        if (InputOrderMessage != null && InputUserName != null)
            SubmitOrderStatus = await dbservice.SaveOrderToDbAsync(order);

        //clear UI form
        InputUserName = string.Empty;
        InputOrderMessage = string.Empty;
    }
}