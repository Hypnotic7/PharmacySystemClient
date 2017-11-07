using System;
using MongoDB.Driver;

namespace PharmacySystemDataAccess.Repository.MongoRepository
{
    public class MongoRepository
    {
        private IMongoClient _MongoClient { get; set; }
        private IMongoDatabase _MongoDatabase { get; set; }

        public MongoRepository(IMongoClient mongoClient)
        {
            _MongoClient = mongoClient;
        }

        public MongoRepository Connect(string databaseName, MongoDatabaseSettings mongoDatabaseSettings = null)
        {
            _MongoDatabase = _MongoClient.GetDatabase(databaseName, mongoDatabaseSettings);
            return this;
        }

        public IMongoCollection<T> GetCollection<T>(string collection)
        {
            if (_MongoDatabase.Equals(null))
                throw new Exception("No Database Available");

            return _MongoDatabase.GetCollection<T>(collection);
        }
    }
}
