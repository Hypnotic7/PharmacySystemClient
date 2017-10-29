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

        public IDataAccess<OrderEntity> AccountRepository { get; }

        public ProductValidation(IRepositoryFactory<OrderEntity> productFactory, string connectionString)
        {

        }

        public bool CheckStock(OrderEntity orderEntity)
        {
            return true;
        }

        public bool ChangeQuantity(OrderEntity orderEntity)
        {
            return true;
        }



    }
}
