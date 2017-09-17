using BussinesAccessLayer.BusinessObjects;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesAccessLayer.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBussinesObject _orderObject)
        {
            return new Order()
            {
                Id = _orderObject.Id,
                OrderDate = _orderObject.OrderDate,
                DeliveryDate = _orderObject.DeliveryDate,
            };
        }

        internal OrderBussinesObject Convert(Order _orderObject)
        {
            return new OrderBussinesObject()
            {
                Id = _orderObject.Id,
                OrderDate = _orderObject.OrderDate,
                DeliveryDate = _orderObject.DeliveryDate,
            };
        }
    }
}
