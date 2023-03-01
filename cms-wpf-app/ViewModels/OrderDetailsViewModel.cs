using Azure.Identity;
using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Net;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class OrderDetailsViewModel : ObservableObject
    {
        private DbService dbService;
        public OrderDetailsViewModel(OrderEntity order)
        {
            dbService = new DbService();
            SetOrderData(order);
        }
        private int OrderId;

        [ObservableProperty]
        private string pageTitle = $"Order from////";



        [ObservableProperty]
        private string orderMessage = null!;
        [ObservableProperty]
        private string orderStatus = null!;

        //[ObservableProperty]
        //private string userName = null!;


        //COMMENTS
        [ObservableProperty]
        private string orderComment = null!;

        [ObservableProperty]
        private string tbuserName = null!;

        private void SetOrderData(OrderEntity order)
        {
            OrderId = order.Id;
            OrderMessage = order.OrderMessage != null ? order.OrderMessage.ToString() : null!;
            OrderStatus = order.Status != null ? order.Status.ToString() : null!;

        }

        [RelayCommand]
        private async Task CreateComment()
        {

            OrderCommentModel comment = new()
            {
                Message = OrderComment,
                UserName = TbuserName,
                OrderId = OrderId
            };

            await dbService.SaveCommentToDbAsync(comment);
            ClearForm();
        }


        public void ClearForm()
        {
            OrderComment = string.Empty;
            UserName = string.Empty;
        }
    }
}
