using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Customer;
using PharmacySystemBusinessLogic.Customer;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private IOptions<AppSettings> _appSettings;
        
        public CustomerController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        // POST api/values
        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerRequest customerRequest)
        {
            CustomerValidation customerValidation = new CustomerValidation(new RepositoryFactory<CustomerEntity>(), _appSettings.Value.MongoConnectionString);

            try
            {
                var customerValidationStatus =
                    customerValidation.CheckDoesTheCustomerExist(customerRequest.FirstName, customerRequest.LastName);
                var returnMessage = customerValidationStatus.IsValid ? $@"{customerValidationStatus.CustomerEntity.CustomerName} has been found" : $@"{customerValidationStatus.CustomerEntity.CustomerName} Not Found";
                return new CustomerResponse()
                {
                    IsValid = customerValidationStatus.IsValid,
                    Message = returnMessage,
                    CustomerEntity = customerValidationStatus.CustomerEntity
                };
            }
            catch (KeyNotFoundException keyNotFound)
            {
                return new CustomerResponse()
                {
                    IsValid = false,
                    Message = keyNotFound.Message
                };
            }


        }
    }
}
