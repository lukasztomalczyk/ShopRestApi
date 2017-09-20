using System.Collections.Generic;
using BussinesAccessLayer.BusinessObjects;
using System;

namespace BussinesAccessLayer
{
    public interface ICustomerService
    {        
        CustomerBussinesObject Create(CustomerBussinesObject _customerBussinesObject);
        
        List<CustomerBussinesObject> GetAll();

        CustomerBussinesObject Get(int _id);
       
        CustomerBussinesObject Update(CustomerBussinesObject _customerBussinesObject);
        
        CustomerBussinesObject Delete(int _id);
    }
}
