using cms_wpf_app.Data;
using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                _customerEntity.Address = new Models.Entities.AddressModel
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

        public async Task SaveOrderToDbAsync(OrderModel order)
        {
            try
            {
                var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserName == order.UserName);
                if (_customer != null)
                    CustomerId = _customer.Id;
            }
            catch{}

            var _orderEntity = new OrderEntity
            {
                CustomerId = CustomerId != Guid.Empty ? CustomerId : Guid.Empty,
                OrderMessage = order.OrderMessage,
                Status = "not-started",
                OrderDate = DateTime.Now,
            };
            _context.Add(_orderEntity);
            await _context.SaveChangesAsync();
        }


        //--------------Get All Orders
        public async Task<List<OrderEntity>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }


        //--------------Get All Customers
        public async Task<List<CustomerEntity>> GetCustomersAsync()
        {
            var _customers = new List<CustomerEntity>();

            foreach (var _customerEntity in await _context.Customers.Include(x => x.Address).ToListAsync())
                _customers.Add(new CustomerEntity
                {
                    Id = _customerEntity.Id,
                    FirstName = _customerEntity.FirstName,
                    LastName = _customerEntity.LastName,
                    UserName = _customerEntity.UserName,
                    Email = _customerEntity.Email,
                    PhoneNumber = _customerEntity.PhoneNumber,
                    Address = _customerEntity.Address
                });

            return _customers;
        }

        //--------------Get Specific Order and comments
        public async Task<OrderEntity> GetOrder(int Id)
        {
            var _order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == Id);

            if (_order != null)
                return _order;

            return null!;
            //var _orderComments = await _context.OrderComments.Include(x => x.Id == Id).ToListAsync();
            //var _orderCommentsList = new List<OrderCommentEntity>();
            //foreach (var _orderComments in await _context.OrderComments.ToListAsync())
            //    _orderCommentsList.Add(new OrderCommentEntity
            //    {
            //        Id = _orderComments.Id,
            //        CustomerId = _orderComments.CustomerId,
            //        OrderId = _orderComments.OrderId,
            //        Message = _orderComments.Message,
            //        MessageDate = _orderComments.MessageDate,
            //    });

            //if (_order != null )
            //  return new OrderModel
            //  {
            //      Id = _order.Id,
            //      CustomerId = _order.CustomerId != Guid.Empty ? _order.CustomerId : Guid.Empty,
            //      Status = _order.Status ?? null!,
            //      OrderDate = _order.OrderDate,
            //      OrderMessage = _order.OrderMessage
            //  };


        }

        public async Task<List<OrderCommentEntity>> GetOrderCommentsAsync(int Id)
        {
            return await _context.OrderComments.Where(x => x.OrderId == Id).ToListAsync();
        }


        //--------------------Save Order Comment to database
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

    }
}
