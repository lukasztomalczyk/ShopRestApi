using DataAccessLayer.Entities;
using BussinesAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BussinesAccessLayer.Converters
{
    class CustomerConverter
    {
        private AddressConverter _converter;

        public CustomerConverter()
        {
            _converter = new AddressConverter();
        }
        internal Customer Convert(CustomerBussinesObject _customerBussinesObject)
        {
            if (_customerBussinesObject == null) { return null;  }

            return new Customer()
            {
                Id = _customerBussinesObject.Id,
                Addresses = _customerBussinesObject.Addresses?.Select(a => new CustomerAddress()
                {
                    AddressId = a.Id,
                    CustomerId = _customerBussinesObject.Id
                }).ToList(),
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
                Addresses = _customerBussinesObject.Addresses.Select(a => new AddressBussinesObject()
                {
                    Id = a.CustomerId,
                    City = a.Address?.City,
                    Street = a.Address?.Street,
                    Number = a.Address?.Number
                }).ToList(),
                FirstName = _customerBussinesObject.FirstName,
                LastName = _customerBussinesObject.LastName
            };
        }
    }
}
