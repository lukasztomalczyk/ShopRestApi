using BussinesAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesAccessLayer
{
    public interface IOrderService
    {
        OrderBussinesObject Create(OrderBussinesObject cust);

        List<OrderBussinesObject> GetAll();

        OrderBussinesObject Get(int Id);

        OrderBussinesObject Update(OrderBussinesObject cust);

        OrderBussinesObject Delete(int Id);
    }
}
