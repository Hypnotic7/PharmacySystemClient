using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemBusinessLogic.RepositoryFactory;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository;

namespace PharmacySystemBusinessLogic.Product
{
    public class ProductValidation
    {

        public IDataAccessFindAll<ProductEntity> ProductRepository { get; }

        public ProductValidation(IRepositoryFactory<ProductEntity> productFactory, string connectionString)
        {
            ProductRepository = (IDataAccessFindAll<ProductEntity>) productFactory.CreateRepository(connectionString, "ProductRepository");
        }

        public ProductValidationStatus GetAllProducts()
        {
            var productValidationStatus = new ProductValidationStatus() { GotAllProducts = false,ProductEntities = new List<ProductEntity>()};

            var products = ProductRepository.FindAll();


            if (!products.Equals(null))
            {
                return new ProductValidationStatus()
                {
                    GotAllProducts = true,
                    ProductEntities = products
                };
            }


            return null;
        }

        public bool CheckStock(ProductEntity productEntity)
        {
            return true;
        }

        public bool ChangeQuantity(ProductEntity productEntity)
        {
            return true;
        }



    }
}
