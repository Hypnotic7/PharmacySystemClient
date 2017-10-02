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

        public void Add(AccountEntity entity)
        {
            throw new NotImplementedException();
        }

        public AccountEntity Find(string id)
        {
            throw new NotImplementedException();
        }

        public void Modify(AccountEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(AccountEntity entity)
        {
            throw new NotImplementedException();
        }

        public AccountRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {
        }
    }
}
