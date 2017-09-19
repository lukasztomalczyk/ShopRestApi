using DataAccessLayer.Entities;
using BussinesAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesAccessLayer.Converters
{
    class CustomerConverter
    {
        internal Customer Convert(CustomerBussinesObject _customerBussinesObject)
        {
            if (_customerBussinesObject == null) { return null;  }

            return new Customer()
            {
                Id = _customerBussinesObject.Id,
                Address = _customerBussinesObject.Address,
                FirstName = _customerBussinesObject.FirstName,
                LastName = _customerBussinesObject.LastName
            };
        }

        internal CustomerBussinesObject Convert(Customer _customerBussinesObject)
        {
            if (_customerBussinesObject == null) { return null; } 

            return new CustomerBussinesObject()
            {
                Id = _customerBussinesObject.Id,
                Address = _customerBussinesObject.Address,
                FirstName = _customerBussinesObject.FirstName,
                LastName = _customerBussinesObject.LastName
            };
        }
    }
}
