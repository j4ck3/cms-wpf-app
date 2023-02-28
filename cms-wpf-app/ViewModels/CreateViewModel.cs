using cms_wpf_app.Data;
using cms_wpf_app.Models.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {
        private static DataContext _context = new DataContext();

        [ObservableProperty]
        private string pageTitle = "Create an Issue";

        public CreateViewModel()
        {

        }

        [RelayCommand]
        private static async Task Create()
        {
            var customerEntity = new CustomerEntity
            {
            };
        }

    }
}
