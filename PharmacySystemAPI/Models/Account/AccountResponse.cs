using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySystemDataAccess.Models.Account;

namespace PharmacySystemAPI.Models.Account
{
    public class AccountResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public AccountEntity Account { get; set; }
    }
}
