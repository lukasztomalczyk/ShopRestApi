using BussinesAccessLayer.Converters;
using BussinesAccessLayer.BusinessObjects;
using BussinesAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Linq;
using DataAccessLayer.Entities;

namespace BussinesAccessLayer.Services
{
    class CustomerService : ICustomerService
    {
        CustomerConverter _converter = new CustomerConverter();
        AddressConverter _converterAddress = new AddressConverter();
        DataAccess _dataAccess;

        public CustomerService(DataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public CustomerBussinesObject Create(CustomerBussinesObject _customerBussines)
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Customer _newCustomer = _unitOfWork.CustomerRepository.Create(_converter.Convert(_customerBussines));
                _unitOfWork.Complete();

                return _converter.Convert(_newCustomer);
            }
        }

        public CustomerBussinesObject Delete(int _idCustommer)
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Customer _newCustomer = _unitOfWork.CustomerRepository.Delete(_idCustommer);
                _unitOfWork.Complete();

                return _converter.Convert(_newCustomer);
            }
        }

        public CustomerBussinesObject Get(int _idCustommer)
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                return _converter.Convert(_unitOfWork.CustomerRepository.Get(_idCustommer));
            }
        }

        public List<CustomerBussinesObject> GetAll()
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            { 
                return _unitOfWork.CustomerRepository.GetAll().Select(_converter.Convert).ToList();
            }
        }

        public CustomerBussinesObject Update(CustomerBussinesObject _customerBussines)
        {
            using (IUnitOfWork _unitOfWork = _dataAccess.UnitOfWork)
            {
                Customer _customerEntity = _unitOfWork.CustomerRepository.Get(_customerBussines.Id);

                if (_customerEntity == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                Customer _customerEntityConvertAddress = _converter.Convert(_customerBussines);
                _customerEntity.FirstName = _customerBussines.FirstName;
                _customerEntity.LastName = _customerBussines.LastName;
                _customerEntity.Addresses = _customerEntityConvertAddress.Addresses;
                _unitOfWork.Complete();

                return _converter.Convert(_customerEntity);
            }

        }

    }
}
