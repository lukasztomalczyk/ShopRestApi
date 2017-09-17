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
        CustomerConverter converter = new CustomerConverter();
        DataAccess dataAccess;

        public CustomerService(DataAccess facade)
        {
            this.dataAccess = facade;
        }

        public CustomerBussinesObject Create(CustomerBussinesObject _customerBussines)
        {
            using (IUnitOfWork _unitOfWork = dataAccess.UnitOfWork)
            {
                Customer _newCustomer = _unitOfWork.CustomerRepository.Create(converter.Convert(_customerBussines));
                _unitOfWork.Complete();

                return converter.Convert(_newCustomer);
            }
        }

        public CustomerBussinesObject Delete(int _idCustommer)
        {
            using (IUnitOfWork _unitOfWork = dataAccess.UnitOfWork)
            {
                Customer _newCustomer = _unitOfWork.CustomerRepository.Delete(_idCustommer);
                _unitOfWork.Complete();

                return converter.Convert(_newCustomer);
            }
        }

        public CustomerBussinesObject Get(int _idCustommer)
        {
            using (IUnitOfWork _unitOfWork = dataAccess.UnitOfWork)
            {
                return converter.Convert(_unitOfWork.CustomerRepository.Get(_idCustommer));
            }
        }

        public List<CustomerBussinesObject> GetAll()
        {
            using (IUnitOfWork _unitOfWork = dataAccess.UnitOfWork)
            { 
                return _unitOfWork.CustomerRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public CustomerBussinesObject Update(CustomerBussinesObject _customerBussines)
        {
            using (IUnitOfWork _unitOfWork = dataAccess.UnitOfWork)
            {
                Customer _customerFromDb = _unitOfWork.CustomerRepository.Get(_customerBussines.Id);

                if (_customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                _customerFromDb.FirstName = _customerBussines.FirstName;
                _customerFromDb.LastName = _customerBussines.LastName;
                _customerFromDb.Address = _customerBussines.Address;
                _unitOfWork.Complete();

                return converter.Convert(_customerFromDb);
            }

        }

    }
}
