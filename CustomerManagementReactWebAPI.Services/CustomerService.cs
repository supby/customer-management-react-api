using CustomerManagementReactWebAPI.Interfaces.Persistence;
using CustomerManagementReactWebAPI.Interfaces.Services;
using CustomerManagementReactWebAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementReactWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Add(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException("customer is null");
            }

            customer.UpdatedOn = DateTime.UtcNow;

            customerRepository.Add(customer);

            return customer;
        }

        public void Delete(int id)
        {
            var entity = customerRepository.FindById(id);
            if(entity == null)
            {
                throw new ApplicationException(string.Format("Customer with id={0} doesn't exist", id));
            }
            customerRepository.Remove(entity);
        }

        public IEnumerable<Customer> Get()
        {
            return customerRepository.Get();
        }

        public Customer Get(int id)
        {
            return customerRepository.FindById(id);
        }

        public Customer Update(int id, Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer is null");
            }

            if (id <= 0)
            {
                throw new ArgumentException("id should be > 0");
            }

            customer.Id = id;
            customer.UpdatedOn = DateTime.UtcNow;

            customerRepository.Update(customer);

            return customer;
        }
    }
}
