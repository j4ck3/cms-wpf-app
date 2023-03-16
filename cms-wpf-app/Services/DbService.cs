using cms_wpf_app.Data;
using cms_wpf_app.Models;
using cms_wpf_app.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace cms_wpf_app.Services
{
    public class DbService
    {

        private static DataContext _context = new();


        //--------------Save Customer to database
        public async Task<string> SaveToDb(CustomerModel customer)
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

            //Execute if UserName is Unique.
            var _user = await _context.Customers.FirstOrDefaultAsync(x => x.UserName == customer.UserName);
            if (_user == null)
            {
                _context.Add(_customerEntity);
                await _context.SaveChangesAsync();
                return "You have been registered!";
            }
            else return "A Customer with that Username Already Exists!";
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
                Status = "Pending",
                OrderDate = DateTime.Now,
            };

            _context.Add(_orderEntity);
            await _context.SaveChangesAsync();
        }


        //--------------Get All Orders
        public async Task<ObservableCollection<OrderEntity>> GetOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            var oc = new ObservableCollection<OrderEntity>();
            orders.ForEach(oc.Add);
            return oc;
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
        public async Task<OrderModel> GetOrder(int Id)
        {

            var _order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == Id);

            var _orderComments = await _context.OrderComments.Where(x => x.OrderId == Id).ToListAsync();


            if (_order != null)
            {
                var orderModel = new OrderModel
                {
                    Id = Id,
                    CustomerId = _order.CustomerId,
                    Status = _order.Status,
                    OrderDate = _order.OrderDate,
                    OrderMessage = _order.OrderMessage,
                    Comments = _orderComments
                };
                return orderModel;
            }
            return null!;
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
        //--------------------Update Order
        public async Task UpdateOrderAsync(OrderModel order)
        {
            var _order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);

            if (order.UserName != null)
            {
                try
                {
                    var _customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserName == order.UserName);
                    if (_customer != null)
                        CustomerId = _customer.Id;
                }
                catch { }
            };


            if (_order != null && order.OrderMessage != null)
            {
                if (CustomerId != Guid.Empty) 
                { _order.CustomerId = CustomerId; }
                if (order.Status != null)
                { _order.Status = order.Status; }
                _order.OrderMessage = order.OrderMessage;
                _context.Update(_order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveOrderAsync(int id)
        {
            var _order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (_order != null)
            {
                _context.Remove(_order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCommentAsync(int id)
        {
            var _comment = await _context.OrderComments.FirstOrDefaultAsync(x => x.Id == id);
            if (_comment != null)
            {
                _context.Remove(_comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
