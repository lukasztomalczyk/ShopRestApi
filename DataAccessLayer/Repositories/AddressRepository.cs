using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using DataAccessLayer.Context;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    class AddressRepository : IAddressRepository
    {
        public ContextDB contextDB { get; internal set; }

        public AddressRepository(ContextDB _contextDB)
        {
            this.contextDB = _contextDB;  
        }

        public Address Create(Address _address)
        {
            contextDB.Addresses.Add(_address);
            return _address;
        }

        public Address Delete(int _id)
        {
            Address _entityAddress = Get(_id);
            contextDB.Addresses.Remove(_entityAddress);
            return _entityAddress;
        }

        public List<Address> GetAll()
        {
            return contextDB.Addresses.ToList();
        }

        public Address Get(int _id)
        {
            return contextDB.Addresses.FirstOrDefault(a => a.Id == _id);
        }
    }
}
