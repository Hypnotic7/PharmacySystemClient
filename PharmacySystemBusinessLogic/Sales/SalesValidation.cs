using System;
using PharmacySystemDataAccess.Models.Sales;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Sales
{
    public class SalesValidation
    {
        public IDataAccess<SalesEntity> SalesRepository { get; }

        public SalesValidation(IRepositoryFactory<SalesEntity> salesFactory, string connectionString)
        {
            SalesRepository =
                salesFactory.CreateRepository(connectionString, "SalesRepository");
        }

        public SalesValidationStatus GetAllSales()
        {
            var salesValidationStatus = new SalesValidationStatus() {GotAllSales = false};

            var sales = SalesRepository.Find(String.Empty);

            if (sales.Equals(null)) return salesValidationStatus;

            salesValidationStatus.GotAllSales = true;
            salesValidationStatus.SalesEntity = sales;
           
            return salesValidationStatus;
        }

        public void UpdateSales(SalesEntity salesEntity)
        {
            SalesRepository.Modify(salesEntity);
        }

    }
}
