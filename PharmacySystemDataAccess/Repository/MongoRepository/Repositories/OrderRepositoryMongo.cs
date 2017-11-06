using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Order;

namespace PharmacySystemDataAccess.Repository.MongoRepository.Repositories
{
    public class OrderRepositoryMongo : MongoRepository, IDataAccess<OrderEntity>
    {
        public string CollectionName => "Orders";
        public static readonly Func<string, OrderRepositoryMongo> OrderRepository = c => new OrderRepositoryMongo(new MongoClient(c));

        public OrderRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {

        }
        
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
    }
}
