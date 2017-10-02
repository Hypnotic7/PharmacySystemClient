using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.MongoRepository;

namespace PharmacySystemBusinessLogic.RepositoryFactory
{
    public class RepositoryFactory<T> : IRepositoryFactory<T>
    {
        public IDataAccess<T> CreateRepository(string connectionString, string type)
        {
            switch (type)
            {
                case "AccountRepository":
                    return (IDataAccess<T>)AccountRepositoryMongo.AccountRepository(connectionString);
                  
                case "ProductRepository":
                    return (IDataAccess<T>) ProductRepositoryMongo.ProductRepository(connectionString);
                
                case "CustomerRepository":
                    return (IDataAccess<T>) CustomerRepositoryMongo.CustomerRepository(connectionString);
                default:
                    throw new ArgumentException(type + " Could not be found");

            }
        }
    }
}
