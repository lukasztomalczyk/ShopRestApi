using BussinesAccessLayer.Services;
using System;
using DataAccessLayer;

namespace BussinesAccessLayer
{
    public class BussinesLogic
    {
        DataAccess dataAccess = new DataAccess();
        private DataAccess _dataAccess;

        public BussinesLogic()
        {
            _dataAccess = dataAccess;
        }
        public ICustomerService CustomerService
        {
            get { return new CustomerService(_dataAccess); }
        }

        public IOrderService OrderService
        {
            get { return new OrderService(_dataAccess); }
        }
    }
}
