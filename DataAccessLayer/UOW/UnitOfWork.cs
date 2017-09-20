using DataAccessLayer.Context;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;

namespace DataAccessLayer.UOW
{
    class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; internal set; }

        public IOrderRepository OrderRepository { get; internal set; }

        public IAddressRepository AddressRepository { get; internal set; }

        private ContextDB context;

        public UnitOfWork()
        {
            context = new ContextDB();
            CustomerRepository = new CustomerRepository(context);
            OrderRepository = new OrderRepository(context);
            AddressRepository = new AddressRepository(context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}

