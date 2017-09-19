using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    class OrderRepository : IOrderRepository
    {
        private ContextDB _context;

        public OrderRepository(ContextDB context)
        {
            _context = context;
        }
        public Order Create(Order _order)
        {
            if (_order.Customer != null)
            {
                _context.Entry(_order.Customer).State = EntityState.Unchanged;
            }
            _context.Orders.Add(_order);
            return _order;
        }

        public Order Delete(int _id)
        {
            Order order = Get(_id);
            _context.Orders.Remove(order);
            return order;
        }

        public Order Get(int _id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == _id);
        }

        public List<Order> GetAll()
        {
           return  _context.Orders.ToList();
        }
    }
}
