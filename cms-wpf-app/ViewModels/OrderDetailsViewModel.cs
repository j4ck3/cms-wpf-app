using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class OrderDetailsViewModel : Core.ViewModel
    {
        private int Id;
        private DbService dbService;

        [ObservableProperty]
        private string pageTitle = $"Order";

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
        public Core.RelayCommand NavigateToOrdersViewCommand { get; set; }
        public OrderDetailsViewModel(INavigationService navigation, int Id)
        {
            dbService = new DbService();
            GetOrderFromDbAsync(Id);
            GetOrderCommentsFromDbAsync(Id);


            Navigation = navigation;
            NavigateToOrdersViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<OrdersViewModel>(); }, o => true);
        }

        private async Task GetOrderFromDbAsync(int Id)
        {
            var _orderModel = await dbService.GetOrder(Id);
            SetOrderData(_orderModel);

        }

        [ObservableProperty]
        private string orderMessage;
        [ObservableProperty]
        private string orderStatus;
        [ObservableProperty]
        private string orderDate;
        [ObservableProperty]
        public List<OrderCommentEntity> comments;


        private async Task GetOrderCommentsFromDbAsync(int Id)
        {
            Comments = await dbService.GetOrderCommentsAsync(Id);
        }

        private void SetOrderData(OrderEntity _orderModel)
        {
            if (_orderModel != null)
            {
                Id = _orderModel.Id;
                 OrderMessage = _orderModel.OrderMessage;
                 OrderStatus = _orderModel.Status ?? null!;
                 OrderDate = _orderModel.OrderDate.ToString();
            }
        }


        #region CreateComment

        [ObservableProperty]
        private string tbOrderComment = string.Empty;

        [ObservableProperty]
        private string tbUserNameCreateOrder = string.Empty;



        //---------Create COMMENTS---------

        [RelayCommand]
        private async Task CreateComment()
        {

            OrderCommentModel comment = new()
            {
                Message = TbOrderComment,
                UserName = TbUserNameCreateOrder,
                OrderId = Id
            };
            
            await dbService.SaveCommentToDbAsync(comment);

            ClearForm();
        }
        public void ClearForm()
        {
            string TbOrderComment = string.Empty;
            string TbUserNameCreateOrder = string.Empty;
        }
        #endregion
    }                                       
}
