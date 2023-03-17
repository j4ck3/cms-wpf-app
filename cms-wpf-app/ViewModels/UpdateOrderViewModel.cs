using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace cms_wpf_app.ViewModels
{
    public partial class UpdateOrderViewModel : Core.ViewModel
    {
        private DbService _dbService;
        public UpdateOrderViewModel(OrderEntity order)
        {
            _dbService = new DbService();
            SetOrder(order);
            statusList = new ObservableCollection<StatusModel>
            {
                new StatusModel { StatusLabel = "PENDING" },
                new StatusModel { StatusLabel = "ONGOING" },
                new StatusModel { StatusLabel = "COMPLETED" }
            };

        }
        [ObservableProperty]
        private string pageTitle = "Update Order";

        [ObservableProperty]
        private string? inputUserName;

        [ObservableProperty]
        private string? inputOrderMessage;

        [ObservableProperty]
        public string? orderStatus;

        [ObservableProperty]
        private ObservableCollection<StatusModel> statusList;

        private StatusModel? _selectedStatus;



        public StatusModel? SelectedStatusInput
        {
            get
            {
                if (_selectedStatus != null)
                    return _selectedStatus;
                return null;
            }
            set 
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatusInput));
            }
        }




        private int id;


        private void SetOrder(OrderEntity order)
        {
            if (order != null)
            {
                id = order.Id;
                InputOrderMessage = order.OrderMessage;
                OrderStatus = order.Status;
            }
        }

        [RelayCommand]
        private async Task UpdateOrder()
        {
                await _dbService.UpdateOrderAsync(new OrderModel
                {
                    Id = id,
                    UserName = InputUserName ?? null!,
                    OrderMessage = InputOrderMessage ?? null!,
                    Status = SelectedStatusInput != null ? SelectedStatusInput.StatusLabel : null,
                });
        }

    }
}
