using System;
using PharmacySystemBusinessLogic.Customer;
using PharmacySystemBusinessLogic.Utilities.Encryption;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Repository;
using PharmacySystemBusinessLogic.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Order
{
    public class ProductValidation
    {
        public IDataAccess<ProductEntity> ProductRepository { get; }

        public ProductValidation(IRepositoryFactory<ProductEntity> productFactory, string connectionString)
        {
            ProductRepository = productFactory.CreateRepository(connectionString, "ProductRepository");
        }

        public ProductValidationStatus ValidateProduct(string ProductName, double Price)
        {
            var ProductValidationStatus = new ProductValidationStatus { IsValid = false};

            if (ProductName.Equals(string.Empty)) return ProductValidationStatus;

            ProductName = ProductName.Trim();

            var product = ProductRepository.Find(ProductName);

            if (product.Equals(null)) return ProductValidationStatus;

            ProductValidationStatus.Product = product;

            return ProductValidationStatus;
        }
    }
}