using System.Collections.Generic;
using BussinesAccessLayer.BusinessObjects;
using System;

namespace BussinesAccessLayer
{
    public interface ICustomerService
    {        
        CustomerBussinesObject Create(CustomerBussinesObject cust);
        
        List<CustomerBussinesObject> GetAll();

        CustomerBussinesObject Get(int Id);
       
        CustomerBussinesObject Update(CustomerBussinesObject cust);
        
        CustomerBussinesObject Delete(int Id);
    }
}
