using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Sales;

namespace PharmacySystemDataAccess.Repository.MongoRepository.Repositories
{
    public class SalesRepositoryMongo : MongoRepository, IDataAccess<SalesEntity>
    {
        public string CollectionName => "Sales";

        public static readonly Func<string, SalesRepositoryMongo> SalesRepository = c =>
            new SalesRepositoryMongo(new MongoClient(c));

        public SalesRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {
        }

        public void Add(SalesEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(SalesEntity entity)
        {
            try
            {
                var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<SalesEntity>(CollectionName);
                collection.ReplaceOne(f => f.SalesId == entity.SalesId, entity);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }

        public SalesEntity Find(string saleType)
        {
            try
            {
                var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<SalesEntity>(CollectionName);
                return collection.Find(new BsonDocument()).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
        }
    }
}