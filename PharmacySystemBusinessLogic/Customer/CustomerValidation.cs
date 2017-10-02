using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemDataAccess.Models.Customer;

namespace PharmacySystemBusinessLogic.Customer
{
    public class CustomerValidation
    {

        public CustomerValidationStatus CheckDoesTheCustomerExist(string customerName)
        {
         
            return new CustomerValidationStatus();
        }

        public CustomerValidationStatus UpdateCustomerDetails(CustomerEntity customerEntity)
        {
            return  new CustomerValidationStatus();
        }
    }
}
