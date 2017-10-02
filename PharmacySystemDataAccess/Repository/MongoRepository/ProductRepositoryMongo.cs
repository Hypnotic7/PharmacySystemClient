using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemDataAccess.Repository.MongoRepository
{
    public class ProductRepositoryMongo : MongoRepository,IDataAccess<ProductEntity>
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
    }
}
