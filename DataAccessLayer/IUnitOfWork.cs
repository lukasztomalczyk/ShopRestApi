using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        int Complete();
    }
}
