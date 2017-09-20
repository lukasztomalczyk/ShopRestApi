using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IAddressRepository
    {
        Address Create(Address _address);

        Address Delete(int _id);

        List<Address> GetAll();

        Address Get(int _id);
    }
}
