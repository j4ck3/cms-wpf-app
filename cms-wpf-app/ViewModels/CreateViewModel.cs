using cms_wpf_app.Models;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "Register";


        private DbService dbservice;
        public CreateViewModel()
        {
            dbservice = new DbService();
        }

        [ObservableProperty]
        private string firstName = null!;
        [ObservableProperty]
        private string lastName = null!;
        [ObservableProperty]
        private string userName = null!;
        [ObservableProperty]
        private string email = null!;
        [ObservableProperty]
        private string phoneNumber = null!;
        [ObservableProperty]
        private string streetName = null!;
        [ObservableProperty]
        private string postalCode = null!;
        [ObservableProperty]
        private string city = null!;

        [RelayCommand]
        private async Task CreateCustomer(string firstName)
        {

            CustomerModel customer = new()
            {
                FirstName = firstName,
                LastName = LastName,
                UserName = UserName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                StreetName = StreetName,
                PostalCode = PostalCode,
                City = City,
            };

           await dbservice.SaveToDb(customer);
            ClearForm();
        }

        //Helper
        public void ClearForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            StreetName = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
        }

    }
}

