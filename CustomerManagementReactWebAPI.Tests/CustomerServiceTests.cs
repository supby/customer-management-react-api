using CustomerManagementReactWebAPI.Interfaces.Persistence;
using CustomerManagementReactWebAPI.Models.Entity;
using CustomerManagementReactWebAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomerManagementReactWebAPI.Tests
{
    public class CustomerServiceTests
    {
        private readonly Mock<IRepository<Customer>> customerRepositoryMock;

        public CustomerServiceTests()
        {
            customerRepositoryMock = new Mock<IRepository<Customer>>();
        }

        [Fact]
        public void AddNewCustomer()
        {
            var customerToAdd = new Customer()
            {
                Name = "FistName",
                Surname = "LastName",
                Address = "Address 1",
                PhoneNumber = "Phone 1"
            };

            customerRepositoryMock.Setup(x => x.Add(It.IsAny<Customer>()));

            var target = new CustomerService(customerRepositoryMock.Object);
            target.Add(customerToAdd);

            customerRepositoryMock.Verify(x =>
                    x.Add(It.Is<Customer>(r =>
                            r.Name.Equals(customerToAdd.Name)
                            && r.Surname.Equals(customerToAdd.Surname)
                            && r.Address.Equals(customerToAdd.Address)
                            && r.PhoneNumber.Equals(customerToAdd.PhoneNumber))), Times.Once);

        }

        [Fact]
        public void AddNewCustomer_NullCustomer()
        {
            var target = new CustomerService(customerRepositoryMock.Object);
            Assert.Throws<ArgumentNullException>(() => target.Add(null));
        }

        [Fact]
        public void DeleteCustomer()
        {
            int customerIdToDelete = 6;

            customerRepositoryMock
                .Setup(x => x.FindById(It.IsAny<int>()))
                .Returns(new Customer()
                {
                    Id = 6,
                    Name = "DeleteMe",
                    Surname = "Please",
                    Address = "Address 1",
                    PhoneNumber = "Phone 1"
                });
            customerRepositoryMock
                .Setup(x => x.Remove(It.IsAny<Customer>()));

            var target = new CustomerService(customerRepositoryMock.Object);
            target.Delete(customerIdToDelete);

            customerRepositoryMock.Verify(x =>
                    x.FindById(It.Is<int>(id => id == customerIdToDelete)), Times.Once);
            customerRepositoryMock.Verify(x =>
                    x.Remove(It.Is<Customer>(c => c.Id == customerIdToDelete)), Times.Once);
        }

        [Fact]
        public void DeleteCustomer_CustomerDoesntExist()
        {
            int notExistedCustomerIdToDelete = 9;

            customerRepositoryMock
                .Setup(x => x.FindById(It.IsAny<int>()))
                .Returns<Customer>(null);
            

            var target = new CustomerService(customerRepositoryMock.Object);
            Assert.Throws<ApplicationException>(() => target.Delete(notExistedCustomerIdToDelete));

            customerRepositoryMock.Verify(x =>
                    x.FindById(It.Is<int>(id => id == notExistedCustomerIdToDelete)), Times.Once);
        }

        [Fact]
        public void GetAll()
        {
            customerRepositoryMock
                .Setup(x => x.Get())
                .Returns(new List<Customer>()
                {
                    new Customer() { Id = 1 },
                    new Customer() { Id = 2 },
                    new Customer() { Id = 3 },
                });
            var target = new CustomerService(customerRepositoryMock.Object);
            var res = target.Get();

            customerRepositoryMock.Verify(x => x.Get(), Times.Once);
            Assert.Equal(3, res.Count());
            Assert.Equal(1, res.ElementAt(0).Id);
            Assert.Equal(2, res.ElementAt(1).Id);
            Assert.Equal(3, res.ElementAt(2).Id);
        }

        [Fact]
        public void GetOne()
        {
            int customerIdToGet = 3;

            customerRepositoryMock
                .Setup(x => x.FindById(It.IsAny<int>()))
                .Returns(new Customer() { Id = customerIdToGet });

            var target = new CustomerService(customerRepositoryMock.Object);
            var res = target.Get(customerIdToGet);

            customerRepositoryMock.Verify(x => x.FindById(It.Is<int>(id => id == customerIdToGet)), Times.Once);
            Assert.Equal(customerIdToGet, res.Id);
        }

        [Fact]
        public void UpdateExistedCustomer()
        {
            int customerToUpdateId = 7;
            var customerToUpdate = new Customer()
            {
                Id = -666, // customerToUpdateId will be used anyway
                Name = "UpdateMe",
                Surname = "Please",
                Address = "Address 1",
                PhoneNumber = "Phone 1"
            };

            customerRepositoryMock
                .Setup(x => x.Update(It.IsAny<Customer>()));

            var target = new CustomerService(customerRepositoryMock.Object);
            target.Update(customerToUpdateId, customerToUpdate);

            customerRepositoryMock.Verify(x => 
                    x.Update(It.Is<Customer>(c => 
                            c.Id == customerToUpdateId
                            && c.Name.Equals(customerToUpdate.Name)
                            && c.Surname.Equals(customerToUpdate.Surname)
                            && c.Address.Equals(customerToUpdate.Address)
                            && c.PhoneNumber.Equals(customerToUpdate.PhoneNumber))), Times.Once);
        }

        [Fact]
        public void UpdateCustomer_NullCustomer()
        {
            var target = new CustomerService(customerRepositoryMock.Object);
            Assert.Throws<ArgumentNullException>(() => target.Update(6, null));
        }

        [Fact]
        public void UpdateCustomer_WithNotValidId()
        {
            var target = new CustomerService(customerRepositoryMock.Object);
            Assert.Throws<ArgumentException>(() => target.Update(-1, new Customer() { Id = 8 }));
        }
    }
}
