using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemDataAccess.Repository.MongoRepository.Repositories
{
    public class ProductRepositoryMongo : MongoRepository,IDataAccessFindAll<ProductEntity>
    {
        public string CollectionName => "Products";
        public static readonly Func<string, ProductRepositoryMongo> ProductRepository = c => new ProductRepositoryMongo(new MongoClient(c));
        public void Add(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public ProductEntity Find(string id)
        {
            throw new NotImplementedException();
        }

        public ProductRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {

        }

       

        public List<ProductEntity> FindAll()
        {
            try
            {
                var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<ProductEntity>(CollectionName);
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
