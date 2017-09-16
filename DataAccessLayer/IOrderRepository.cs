using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IOrderRepository
    {
        Order Create(Order _order);
        
        List<Order> GetAll();

        Order Get(int _id);

        Order Delete(int _id);
    }
}
