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

/*public SalesEntity Find(int saleType)
{
    try
    {
        var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<ProductEntity>(CollectionName);
        var product = collection.Find(f => f.ProductName.Equals(productName)).FirstOrDefault();

        if (product != null)
            return new ProductEntity()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = product.Quantity,
                RequiresPrescription = product.RequiresPrescription,
                Container = product.Container
            };
    }
    catch (Exception e)
    {
        throw new KeyNotFoundException($"Product not found: {productName}");
    }

    throw new KeyNotFoundException($"Product Name not found: {productName}");

    throw new NotImplementedException();
}


public SalesRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
{
    throw new NotImplementedException();
}



public List<SalesEntity> FindAll()
{
    try
    {
        var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<SalesEntity>(CollectionName);
        return collection.Find(new BsonDocument()).ToList();
    }
    catch (Exception e)
    {
        throw new NotImplementedException();
    }
}
}
}*/