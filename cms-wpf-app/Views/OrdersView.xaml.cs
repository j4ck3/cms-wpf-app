using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using cms_wpf_app.ViewModels;
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
        public INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is OrderEntity order)
            {
                GotodetailsView(_navigation);
            }

            void GotodetailsView(INavigationService navigation)
            {
                Navigation = navigation;
                Navigation.NavigateTo < OrderDetailsViewModel > ();

            }

        }
    }
}
