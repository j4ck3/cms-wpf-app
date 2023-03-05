﻿using cms_wpf_app.Models.Entities;
using cms_wpf_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CustomersViewModel : Core.ViewModel
    {

        [ObservableProperty]
        private string pageTitle = "Customers";

        private DbService dbService;

        [ObservableProperty]
        public List<CustomerEntity> customers;

        public CustomersViewModel()
        {
            dbService = new DbService();
            GetAllCustomersAsync();
        }

        private async Task<List<CustomerEntity>> GetAllCustomersAsync()
        {
            Customers = await dbService.GetCustomersAsync();
            return Customers;
        }
    }
}
