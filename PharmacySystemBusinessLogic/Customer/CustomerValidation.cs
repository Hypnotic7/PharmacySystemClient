using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Customer
{
    public class CustomerValidation
    {
        public IDataAccess<CustomerEntity> CustomerRepository { get; }

        public CustomerValidation(IRepositoryFactory<CustomerEntity> customerFactory, string connectionString)
        {
            CustomerRepository = customerFactory.CreateRepository(connectionString, "CustomerRepository");
        }

        public CustomerValidationStatus CheckDoesTheCustomerExist(string firstName, string lastName)
        {
            var customerValidationStatus = new CustomerValidationStatus() {IsValid = false};

            if (firstName.Equals(string.Empty)) return customerValidationStatus;
            if (lastName.Equals(string.Empty)) return customerValidationStatus;
            var customerName = firstName.Trim() + " " + lastName.Trim();

            var customer = CustomerRepository.Find(customerName);

            if (customer.Equals(null)) return customerValidationStatus;

            customerValidationStatus.IsValid = true;
            customerValidationStatus.CustomerEntity = customer;
            return customerValidationStatus;
        }

        public CustomerValidationStatus UpdateCustomerDetails(CustomerEntity customerEntity)
        {
            return  new CustomerValidationStatus();
        }
    }
}
