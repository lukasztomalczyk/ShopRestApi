using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IAdressRepository AdressRepository { get; }

        int Complete();
    }
}
