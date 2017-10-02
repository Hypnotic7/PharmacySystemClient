using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models;
using PharmacySystemDataAccess.Models.Customer;

namespace PharmacySystemDataAccess.Repository.MongoRepository
{
    public class CustomerRepositoryMongo : MongoRepository, IDataAccess<CustomerEntity>
    {
        public CustomerRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public string CollectionName => "Customers";
        public static readonly Func<string, AccountRepositoryMongo> CustomerRepository = c => new AccountRepositoryMongo(new MongoClient(c));

        public void Add(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }

        public CustomerEntity Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}
