using CustomerManagementReactWebAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementReactWebAPI.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();

        Customer Get(int id);

        Customer Add(Customer customer);

        Customer Update(int id, Customer customer);

        void Delete(int id);
    }
}
