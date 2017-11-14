using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Customer;

namespace PharmacySystemDataAccess.Repository.MongoRepository.Repositories
{
    public class CustomerRepositoryMongo : MongoRepository, IDataAccess<CustomerEntity>
    {
        public CustomerRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public string CollectionName => "Customers";
        public static readonly Func<string, CustomerRepositoryMongo> CustomerRepository = c => new CustomerRepositoryMongo(new MongoClient(c));

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

        public CustomerEntity Find(string customerName)
        {
            try
            {
                var collection = Connect(DataAccessConstants.DatabaseName)
                    .GetCollection<CustomerEntity>(CollectionName);
                var customer = IMongoCollectionExtensions
                    .Find<CustomerEntity>(collection, f => f.CustomerName.Equals(customerName)).FirstOrDefault();

                if (customer != null)
                {
                    return new CustomerEntity()
                    {
                        CustomerId = customer.CustomerId,
                        CustomerName = customer.CustomerName,
                        DateOfBirth = customer.DateOfBirth,
                        Address = customer.Address,
                        PhoneNumber = customer.PhoneNumber,
                        SchemesCards = customer.SchemesCards

                    };
                }
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException($"Customer Name not found: {customerName}");
            }

            throw new KeyNotFoundException($"Customer Name not found: {customerName}");
        }
    }
}
