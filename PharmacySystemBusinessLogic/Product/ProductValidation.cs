using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemBusinessLogic.RepositoryFactory;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository;

namespace PharmacySystemBusinessLogic.Product
{
    public class ProductValidation
    {

        public IDataAccess<ProductEntity> AccountRepository { get; }

        public ProductValidation(IRepositoryFactory<ProductEntity> productFactory, string connectionString)
        {

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
