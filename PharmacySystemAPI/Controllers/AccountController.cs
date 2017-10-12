using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacySystemAPI.Models.Account;
using PharmacySystemBusinessLogic.Account.Validation;

namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        // POST api/values
        [HttpPost]
        
        public AccountResponse Post([FromBody]AccountRequest accountRequest)
        {
            AccountValidation accountValidation;
      
            
            return new AccountResponse();
        }

        //// POST api/values
        //[HttpPost]

        //public AccountResponse CreateAccount([FromBody]AccountRequest accountRequest)
        //{
        //    AccountValidation accountValidation;
        //    return new AccountResponse();
        //}

    }
}
