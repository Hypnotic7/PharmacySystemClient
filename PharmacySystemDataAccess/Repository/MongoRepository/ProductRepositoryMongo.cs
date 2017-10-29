using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemDataAccess.Repository.MongoRepository
{
    public class ProductRepositoryMongo : MongoRepository,IDataAccess<OrderEntity>
    {
        public string CollectionName => "Products";
        public static readonly Func<string, ProductRepositoryMongo> ProductRepository = c => new ProductRepositoryMongo(new MongoClient(c));

        public void Add(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public OrderEntity Find(string id)
        {
            throw new NotImplementedException();
        }

        public ProductRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {

        }
    }
}
