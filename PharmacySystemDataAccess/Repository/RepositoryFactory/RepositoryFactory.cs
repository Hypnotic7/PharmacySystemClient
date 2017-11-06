using System;
using PharmacySystemDataAccess.Repository.MongoRepository;
using PharmacySystemDataAccess.Repository.MongoRepository.Repositories;

namespace PharmacySystemDataAccess.Repository.RepositoryFactory
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
                    return (IDataAccessFindAll<T>) ProductRepositoryMongo.ProductRepository(connectionString);
                
                //case "CustomerRepository":
                //    return (IDataAccess<T>) CustomerRepositoryMongo.CustomerRepository(connectionString);
                default:
                    throw new ArgumentException(type + " Could not be found");

            }
        }
    }
}
