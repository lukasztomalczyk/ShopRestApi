using BussinesAccessLayer.Converters;
using BussinesAccessLayer.BusinessObjects;
using BussinesAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using System.Linq;

namespace BussinesAccessLayer.Services
{
    class CustomerService : ICustomerService
    {
        CustomerConverter conv = new CustomerConverter();
        DataAccess facade;

        public CustomerService(DataAccess facade)
        {
            this.facade = facade;
        }

        public CustomerBussinesObject Create(CustomerBussinesObject cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();
                return conv.Convert(newCust);
            }
        }

        public CustomerBussinesObject Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newCust);
            }
        }

        public CustomerBussinesObject Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.CustomerRepository.Get(Id));
            }
        }

        public List<CustomerBussinesObject> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                return uow.CustomerRepository.GetAll().Select(conv.Convert).ToList();
            }
        }

        public CustomerBussinesObject Update(CustomerBussinesObject cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }

                customerFromDb.FirstName = cust.FirstName;
                customerFromDb.LastName = cust.LastName;
                customerFromDb.Address = cust.Address;
                uow.Complete();
                return conv.Convert(customerFromDb);
            }

        }

    }
}
