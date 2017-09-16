using DataAccessLayer.Repositories;
using DataAccessLayer.UOW;
using System;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public ICustomerRepository CustomerRepository
        {
            //get { return new CustomerRepositoryFakeDB(); }
            get
            {
                return new CustomerRepository(
                    new Context.ContextDB());
            }
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
