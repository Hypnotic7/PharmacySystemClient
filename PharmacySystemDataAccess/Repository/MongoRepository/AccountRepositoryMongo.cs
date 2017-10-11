using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models;
using PharmacySystemDataAccess.Models.Account;

namespace PharmacySystemDataAccess.Repository.MongoRepository
{
    public class AccountRepositoryMongo : MongoRepository, IDataAccess<AccountEntity>
    {
        public string CollectionName => "Accounts";
        public static readonly Func<string, AccountRepositoryMongo> AccountRepository = c => new AccountRepositoryMongo(new MongoClient(c));

        private AccountRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {

        }

        public void Add(AccountEntity entity)
        {
            throw new NotImplementedException();
        }

        public AccountEntity Find(string accountName)
        {
            try
            {
                var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<AccountEntity>(CollectionName);
                var account = collection.Find(f => f.AccountName.Equals(accountName)).FirstOrDefault();

                if (account != null)
                    return new AccountEntity()
                    {
                        AccountId = account.AccountId,
                        AccountName = account.AccountName,
                        Password = account.Password,
                        IsLoggedIn = account.IsLoggedIn,
                        LastLoginDate = account.LastLoginDate
                    };
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException($"Account Name not found: {accountName}");
            }

            throw new KeyNotFoundException($"Account Name not found: {accountName}");
        }

        public void Modify(AccountEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(AccountEntity entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
