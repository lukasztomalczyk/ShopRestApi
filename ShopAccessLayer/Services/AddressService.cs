using System;
using System.Collections.Generic;
using System.Text;
using BussinesAccessLayer.BusinessObjects;
using BussinesAccessLayer.Converters;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System.Linq;

namespace BussinesAccessLayer.Services
{
    public class AddressService : IAddressService
    {
        private DataAccess _dataAccess;
        private AddressConverter _converterAddress;

        public AddressService(DataAccess dataAccess )
        {
            this._dataAccess = dataAccess;
            _converterAddress = new AddressConverter();
        }

        public AddressBussinesObject Create(AddressBussinesObject _addressBussinesObject)
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Address _newAddress = _unitOfWork.AddressRepository.Create(_converterAddress.Convert(_addressBussinesObject));
                _unitOfWork.Complete();
                return _converterAddress.Convert(_newAddress);
            }
        }

        public AddressBussinesObject Delete(int _id)
        {
            using(IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Address _addressEntity = _dataAccess.UnitOfWork.AddressRepository.Delete(_id);
                _unitOfWork.Complete();
                return _converterAddress.Convert(_addressEntity);
            }
        }

        public AddressBussinesObject Get(int _id)
        {
            using(IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Address _addressEntity = _unitOfWork.AddressRepository.Get(_id);
                return _converterAddress.Convert(_addressEntity);
            }
        }

        public List<AddressBussinesObject> GetAll()
        {
            using(IUnitOfWork _unitOfwork = _dataAccess.UnitOfWork)
            {
                return _unitOfwork.AddressRepository.GetAll().Select(_converterAddress.Convert).ToList();
            }
        }

     /*   public AddressBussinesObject Update(AddressBussinesObject address)
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Address _addressEntity = _unitOfWork.AddressRepository.
            }
        }  */
    }
}
