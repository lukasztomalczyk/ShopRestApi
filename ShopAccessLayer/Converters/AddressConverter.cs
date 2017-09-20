using BussinesAccessLayer.BusinessObjects;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesAccessLayer.Converters
{
    class AddressConverter
    {
        internal Address Convert(AddressBussinesObject _addressBussinesObject)
        {
            if (_addressBussinesObject == null) { return null; }

            return new Address()
            {
                Id = _addressBussinesObject.Id,
                Number = _addressBussinesObject.Number,
                City = _addressBussinesObject.City,
                Street = _addressBussinesObject.Street
            };
        }

        internal AddressBussinesObject Convert(Address _address)
        {
            if (_address == null) { return null; }

            return new AddressBussinesObject()
            {
                Id = _address.Id,
                Number = _address.Number,
                City = _address.City,
                Street = _address.Street
            };
        }
    }
}
