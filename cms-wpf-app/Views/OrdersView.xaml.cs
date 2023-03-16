using cms_wpf_app.Models.Entities;
using cms_wpf_app.ViewModels;
using System.Windows;
using System.Windows.Controls;
using cms_wpf_app.Services;

namespace cms_wpf_app.Views;


public partial class OrdersView : UserControl
{

    private readonly DbService _dbService;
    public OrdersView()
    {
        InitializeComponent();
        _dbService = new DbService();
    }

    private void Edit_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Button? button = sender as Button;

        if (button.DataContext is OrderEntity order)
        {
            DataContext = new UpdateOrderViewModel(order);
            UpdateOrderView UpdateView = new();
            Content = UpdateView;
        }
    }

    private async void Delete_order_Click(object sender, System.Windows.RoutedEventArgs e)
    {

        if (Orders_Grid.SelectedItem is OrderEntity order)
        {
            if (MessageBox.Show($"Are you sure you want to delete the Order?",
            "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                await _dbService.RemoveOrderAsync(order.Id);
            }
        }
    }
}