using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemBusinessLogic.RepositoryFactory;
using PharmacySystemDataAccess.Models;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Repository;

namespace PharmacySystemBusinessLogic.Account.Validation
{
    public class AccountValidation
    {
        public IDataAccess<AccountEntity> AccountRepository { get; }

        public AccountValidation(IRepositoryFactory<AccountEntity> accountFactory, string connectionString)
        {
            
        }

        public AccountValidationStatus ValidateLoginAccount(string accountName, string accountPassword)
        {
            return new AccountValidationStatus();
        }

        public AccountValidationStatus CreateAccount(string accountName, string accountPassword, string name)
        {
            return new AccountValidationStatus();
        }
    }
}