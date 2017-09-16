using DataAccessLayer.Entities;
using BussinesAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesAccessLayer.Converters
{
    class CustomerConverter
    {
        internal Customer Convert(CustomerBussinesObject cust)
        {
            return new Customer()
            {
                Id = cust.Id,
                Address = cust.Address,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }

        internal CustomerBussinesObject Convert(Customer cust)
        {
            return new CustomerBussinesObject()
            {
                Id = cust.Id,
                Address = cust.Address,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
