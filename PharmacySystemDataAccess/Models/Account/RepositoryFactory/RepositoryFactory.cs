using System;
using PharmacySystemBusinessLogic.RepositoryFactory;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.MongoRepository;

namespace PharmacySystemDataAccess.Models.Account.RepositoryFactory
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
                
                //case "CustomerRepository":
                //    return (IDataAccess<T>) CustomerRepositoryMongo.CustomerRepository(connectionString);
                default:
                    throw new ArgumentException(type + " Could not be found");

            }
        }
    }
}
