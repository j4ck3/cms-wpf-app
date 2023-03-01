using cms_wpf_app.ViewModels;
using System.Windows.Controls;

namespace cms_wpf_app.Views
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView : UserControl
    {
        public OrderDetailsView()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Content = new OrdersViewModel();
        }
    }
}
