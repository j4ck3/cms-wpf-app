using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public OrderDetailsViewModel(INavigationService navigationService)
        {
            dbService = new DbService();
            GetOrderFromDb(Id);
            GetAllOrders();
            


            Navigation = navigationService;
            NavigateToOrdersViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<OrdersViewModel>(); }, o => true);
        }

        [ObservableProperty]
        private ObservableCollection<OrderEntity> orderList = new();

        private async Task<ObservableCollection<OrderEntity>> GetAllOrders()
        {
            return OrderList = await dbService.GetOrdersAsync();
            // return OrderList;
        }

        private OrderEntity? _selectedOrder;

        public OrderEntity? SelectedOrder
        {
            get
            {
                if (_selectedOrder != null)
                    return _selectedOrder;
                return null;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }


        private async Task<OrderEntity> GetOrderFromDb(int Id)
        {
            var _orderModel = await dbService.GetOrder(Id);
            return _orderModel;
        }

        [ObservableProperty]
        private string orderMessage;
        [ObservableProperty]
        private string orderStatus;
        [ObservableProperty]
        private string orderDate;
        [ObservableProperty]
        private List<OrderCommentEntity> comments;


        private void SetOrderData(OrderEntity _orderModel)
        {
            if (_orderModel != null)
            {
                //se enklare sätt.
                Id = _orderModel.Id;
                OrderMessage = _orderModel.OrderMessage;
                OrderStatus = _orderModel.Status ?? null!;
                OrderDate = _orderModel.OrderDate.ToString();
            }
        }
        //private async Task GetOrderCommentsFromDbAsync(int Id)
        //{
        //    Comments = await dbService.GetOrderCommentsAsync(Id);
        //}

        #region CreateComment

        [ObservableProperty]
        private string tbOrderComment = string.Empty;

        [ObservableProperty]
        private string tbUserNameCreateMessage = string.Empty;



        //---------Create COMMENTS---------

        [RelayCommand]
        private async Task CreateComment()
        {

            OrderCommentModel comment = new()
            {
                Message = TbOrderComment,
                UserName = TbUserNameCreateMessage,
                OrderId = Id
            };
            
            await dbService.SaveCommentToDbAsync(comment);

            ClearForm();
        }
        public void ClearForm()
        {
            TbOrderComment = string.Empty;
            TbUserNameCreateMessage = string.Empty;
        }
        #endregion
    }                                       
}
