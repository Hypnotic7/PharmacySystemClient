using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemDataAccess.Models;
using PharmacySystemDataAccess.Models.Account;

namespace PharmacySystemBusinessLogic.Account.Validation
{
    public class ProductValidationStatus
    {
        public bool IsValid { get; set; }
        public AccountEntity Account { get; set; }
    }
}
