using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Account;
using PharmacySystemBusinessLogic.Account.Validation;
using PharmacySystemBusinessLogic.RepositoryFactory;
using PharmacySystemDataAccess.Models.Account;

namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private IOptions<AppSettings> _appSettings;

        public AccountController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        // POST api/values
        [HttpPost]
     
        public AccountResponse Post([FromBody]AccountRequest accountRequest)
        {
            AccountValidation accountValidation = new AccountValidation(new RepositoryFactory<AccountEntity>(), _appSettings.Value.MongoConnectionString);

            try
            {
                var accountValidationStatus = accountValidation.ValidateAccount(accountRequest.AccountName, accountRequest.AccountPassword);
                var returnMessage = accountValidationStatus.IsValid ? $@"{accountValidationStatus.Account.AccountName} has been found" : $@"{accountValidationStatus.Account.AccountName} Not Found";
                return new AccountResponse()
                {
                    IsValid = accountValidationStatus.IsValid,
                    Message = returnMessage
                };
            }
            catch (KeyNotFoundException keyNotFound)
            {
                return new AccountResponse()
                {
                    IsValid = false,
                    Message = keyNotFound.Message
                };
            }
        }

    }
}
