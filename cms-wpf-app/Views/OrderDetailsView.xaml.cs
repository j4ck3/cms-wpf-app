using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using cms_wpf_app.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace cms_wpf_app.Views;

public partial class OrderDetailsView : UserControl
{
    private readonly DbService _dbService;
    public OrderDetailsView()
    {
        InitializeComponent();
        _dbService = new DbService();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {

        Button? button = sender as Button;
        if (button.DataContext is OrderCommentEntity comment)
        {
            if (MessageBox.Show($"Are you sure you want to delete the comment?",
            "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                await _dbService.RemoveCommentAsync(comment.Id);
            }
        }
    }
}
