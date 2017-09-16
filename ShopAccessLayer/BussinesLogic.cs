using BussinesAccessLayer.Services;
using System;
using DataAccessLayer;

namespace BussinesAccessLayer
{
    public class BussinesLogic
    {
        public ICustomerService CustomerService
        {
            get { return new CustomerService(new DataAccess()); }
        }
    }
}
