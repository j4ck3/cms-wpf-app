using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class OrderDetailsViewModel : Core.ViewModel
    {


        #region init database service & navigation commands

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

            Navigation = navigationService;
            NavigateToOrdersViewCommand = new Core.RelayCommand(o => { Navigation.NavigateTo<OrdersViewModel>(); }, o => true);
        }

        #endregion


        #region get order and comments set to ObservableProperty
        [ObservableProperty]
        private OrderEntity currentOrder;

        private int id;

        [ObservableProperty]
        private int orderSearch;


        [RelayCommand]
        private async Task<OrderEntity> GetOrder()
        {
            return CurrentOrder = await dbService.GetOrder(OrderSearch);
        }

        #endregion


        #region CreateComment

        [ObservableProperty]
        private string tbOrderComment = string.Empty;

        [ObservableProperty]
        private string tbUserNameCreateMessage = string.Empty;

        [ObservableProperty]
        private string submitCommentStatus = string.Empty;


        //---------Submit comment to order---------

        [RelayCommand]
        private async Task CreateComment()
        {

            OrderCommentModel comment = new()
            {
                Message = TbOrderComment,
                UserName = TbUserNameCreateMessage,
                OrderId = CurrentOrder.Id
            };

            if (TbOrderComment != null)
            {
                SubmitCommentStatus = await dbService.SaveCommentToDbAsync(comment);
            }
            TbOrderComment = string.Empty;
            TbUserNameCreateMessage = string.Empty;
        }
        #endregion
    }                                       
}