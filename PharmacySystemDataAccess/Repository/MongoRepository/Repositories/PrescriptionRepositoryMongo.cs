using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Models.Prescription;

namespace PharmacySystemDataAccess.Repository.MongoRepository.Repositories
{
    public class PrescriptionRepositoryMongo : MongoRepository,IDataAccess<PrescriptionEntity>
    {
        public string CollectionName => "Prescriptions";
        public static readonly Func<string, PrescriptionRepositoryMongo> PrescriptionRepository = c => new PrescriptionRepositoryMongo(new MongoClient(c));

        public void Add(PrescriptionEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(PrescriptionEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Modify(PrescriptionEntity entity)
        {
            throw new NotImplementedException();
        }

        public PrescriptionEntity Find(string name)
        {
            try
            {
                var collection = Connect(DataAccessConstants.DatabaseName).GetCollection<PrescriptionEntity>(CollectionName);
                var prescription = IMongoCollectionExtensions.Find<PrescriptionEntity>(collection, f => f.CustomerName.Equals(name) || f.GpName.Equals(name)).FirstOrDefault();

                if (prescription != null)
                    return new PrescriptionEntity()
                    {
                        PrescriptionId = prescription.PrescriptionId,
                        CustomerName = prescription.CustomerName,
                        GpName = prescription.GpName,
                        Products = prescription.Products
                    };
            }
            catch (Exception e)
            {
                throw new KeyNotFoundException($"Customer or GP name not found: {name}");
            }

            throw new KeyNotFoundException($"Customer or GP name not found: {name}");
        }

        public PrescriptionRepositoryMongo(IMongoClient mongoClient) : base(mongoClient)
        {

        }
    }
}
