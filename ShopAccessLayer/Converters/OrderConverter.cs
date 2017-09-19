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
            if (_orderObject == null ) { return null;  }

            return new Order()
            {
                Id = _orderObject.Id,
                OrderDate = _orderObject.OrderDate,
                DeliveryDate = _orderObject.DeliveryDate,
                Customer = new CustomerConverter().Convert(_orderObject.Customer),
                CustomerId = _orderObject.CustomerId
            };
        }

        internal OrderBussinesObject Convert(Order _orderObject)
        {
            if (_orderObject == null) { return null; }

            return new OrderBussinesObject()
            {
                Id = _orderObject.Id,
                OrderDate = _orderObject.OrderDate,
                DeliveryDate = _orderObject.DeliveryDate,
                Customer = new CustomerConverter().Convert(_orderObject.Customer),
                 CustomerId = _orderObject.CustomerId
            };
        }
    }
}
