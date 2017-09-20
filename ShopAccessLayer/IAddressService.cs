
using BussinesAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesAccessLayer
{
    public interface IAddressService
    {
        AddressBussinesObject Create(AddressBussinesObject _addressBussinesObject);

        AddressBussinesObject Delete(int _id);

        AddressBussinesObject Get(int _id);

        List<AddressBussinesObject> GetAll();

      //  AddressBussinesObject Update(AddressBussinesObject _addressBussinesObject);
    }
}
