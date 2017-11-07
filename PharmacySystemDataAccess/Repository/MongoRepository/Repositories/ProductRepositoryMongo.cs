using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
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
            try
            {
                var entityFromDb = Find(entity.ProductName);
                entityFromDb.Quantity -= entity.Quantity;
                var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<ProductEntity>(CollectionName);
                collection.ReplaceOne(f => f.ProductName.Equals(entity.ProductName), entityFromDb);
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            
        }

        public ProductEntity Find(string productName)
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
        }
    }
}
