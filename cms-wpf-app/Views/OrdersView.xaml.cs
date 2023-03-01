using cms_wpf_app.Models.Entities;
using cms_wpf_app.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace cms_wpf_app.Views
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public OrdersView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is OrderEntity order)
            {
                DataContext = new OrderDetailsViewModel(order);
                OrderDetailsView OrderDetailsView = new();
                Content = OrderDetailsView;
            }

        }
    }
}
