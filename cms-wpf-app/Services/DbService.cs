using cms_wpf_app.Data;
using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.RightsManagement;
using System.Threading.Tasks;
using System.Windows;

namespace cms_wpf_app.Services
{
    public class DbService
    {

        private static DataContext _context = new();


        public async Task SaveToDb(CustomerModel customer)
        {
            var _customerEntity = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
            };

            var _addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == customer.StreetName && x.PostalCode == customer.PostalCode && x.City == customer.City);
            if (_addressEntity != null)
                _customerEntity.AddressId = _addressEntity.Id;
            else
                _customerEntity.Address = new AddressEntity
                {
                    CustomerId = customer.Id,
                    StreetName = customer.StreetName,
                    PostalCode = customer.PostalCode,
                    City = customer.City
                };

            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }


        public async Task SaveOrderToDb(OrderModel order)
        {
            try
            {
                var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserName == order.UserName);
                if (_customer != null)
                {
                    var _orderEntity = new OrderEntity
                    {
                        CustomerId = _customer.Id,
                        OrderMessage = order.OrderMessage,
                        Status = order.Status,
                        OrderDate = DateTime.Now,
                    };
                    _context.Add(_orderEntity);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
            }
        }
    }
}
