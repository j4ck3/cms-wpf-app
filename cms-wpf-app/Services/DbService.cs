using cms_wpf_app.Data;
using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cms_wpf_app.Services
{
    public class DbService
    {

        private static DataContext _context = new();


        //--------------Save Customer to database
        public async Task SaveToDb(CustomerModel customer)
        {
            var _customerEntity = new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                UserName = customer.UserName,
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

        //--------------Save Order to database
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
                        Status = "not-started",
                        OrderDate = DateTime.Now,
                    };
                    _context.Add(_orderEntity);
                    await _context.SaveChangesAsync();
                }
            }
            catch{}
        }


        //--------------Get All Orders
        public async Task<List<OrderEntity>> GetOrders()
        {
            return  await _context.Orders.ToListAsync();
        }


        //--------------Get All Customers
        public async Task<List<CustomerModel>> GetCustomers()
        {
            //return await _context.Customers.ToListAsync();

            var _customers = new List<CustomerModel>();

            foreach (var _customer in await _context.Customers.Include(x => x.Address).ToListAsync())
                _customers.Add(new CustomerModel
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber,
                    StreetName = _customer.Address.StreetName,
                    PostalCode = _customer.Address.PostalCode,
                    City = _customer.Address.City
                });

            return _customers;
        }

        //--------------Get Specific Order
        public async Task<OrderEntity>GetOrder(int Id)
        {
            var _orderEntity = await _context.Orders.FirstOrDefaultAsync(x => x.Id == Id);

            if (_orderEntity != null )
                return _orderEntity;

            return null! ;
        }


        //--------------------Save Comment to database
        private Guid CustomerId;

        public async Task SaveCommentToDbAsync(OrderCommentModel comment)
        {
            try
            {
                var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserName == comment.UserName);
                if (_customer != null)
                    CustomerId = _customer.Id;
            }
            catch { }

            var _orderCommentEntity = new OrderCommentEntity
            {
                CustomerId = CustomerId != Guid.Empty ? CustomerId : Guid.Empty,
                OrderId = comment.OrderId,
                Message = comment.Message,
                MessageDate = DateTime.Now,
            };
            _context.Add(_orderCommentEntity);
            await _context.SaveChangesAsync();
        }


        //--------------Get Order Comments
        //public async Task<OrderEntity> GetOrderComments(int Id)
        //{

        //}
    }
}
