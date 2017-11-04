using System;
using PharmacySystemBusinessLogic.Utilities.Encryption;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Repository;
using PharmacySystemBusinessLogic.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Account.Validation
{
    public class AccountValidation
    {
        public IDataAccess<AccountEntity> AccountRepository { get; }

        public AccountValidation(IRepositoryFactory<AccountEntity> accountFactory, string connectionString)
        {
            AccountRepository = accountFactory.CreateRepository(connectionString, "AccountRepository");
        }

        public ProductValidationStatus ValidateAccount(string accountName, string password)
        {
            var accountValidationStatus = new ProductValidationStatus { IsValid = false };

            if (accountName.Equals(string.Empty)) return accountValidationStatus;
            if (password.Equals(string.Empty)) return accountValidationStatus;

            accountName = accountName.Trim();
            password = password.Trim();

            var account = AccountRepository.Find(accountName);

            if (account.Equals(null)) return accountValidationStatus;

            accountValidationStatus.IsValid = account.Password.Equals(EncryptionUtility.ComputePasswordHashValue(password));

            if (accountValidationStatus.IsValid)
            {
                account.IsLoggedIn = !account.IsLoggedIn;
                account.LastLoginDate = DateTime.Now;
                //AccountRepository.Modify(account);
            }

            accountValidationStatus.Account = account;

            return accountValidationStatus;
        }
    }
}