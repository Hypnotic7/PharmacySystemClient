using System;
using System.Collections.Generic;
using System.Linq;
using PharmacySystemBusinessLogic.Account.Validation;
using PharmacySystemBusinessLogic.Customer;
using PharmacySystemBusinessLogic.Product;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Order
{
    public class OrderValidation
    {
        public IDataAccess<OrderEntity> OrderRepository { get; }
        public string ConnString { private set; get; }

        public OrderValidation(IRepositoryFactory<OrderEntity> orderFactory, string connectionString)
        {
            ConnString = connectionString;
             OrderRepository = orderFactory.CreateRepository(ConnString, "OrderRepository");
        }

        public OrderValidationStatus ValidateOrder(string accName,string custName, List<ProductEntity> products)
        {
            var orderValidationStatus = new OrderValidationStatus() {IsValid = false};

            if (accName.Equals(null) || custName.Equals(null) || products.Equals(null)) return orderValidationStatus;

            var accountName = accName.Trim();
            var customerName = custName.Trim();


            var account = ValidateAccountEntity(accountName);

            if (account == null)
                return orderValidationStatus;

            var customer = ValidateCustomerEntity(customerName);

            if (customer == null)
                return orderValidationStatus;

            var productList = ValidateProducts(products);

            if (productList.Equals(null))
                return orderValidationStatus;


            return null;
        }

        private AccountEntity ValidateAccountEntity(string accName)
        {
            AccountValidation accountValidation = new AccountValidation(new RepositoryFactory<AccountEntity>(), ConnString);
            
            return accountValidation.ValidateAccount(accName, "s", true).Account; 
        }

        private CustomerEntity ValidateCustomerEntity(string custName)
        {
            CustomerValidation customerValidation = new CustomerValidation(new PharmacySystemDataAccess.Repository.RepositoryFactory.RepositoryFactory<CustomerEntity>(), ConnString);
            var customerName = custName.Split(' ');        
                
            return customerValidation.CheckDoesTheCustomerExist(customerName[0], customerName[1]).CustomerEntity;
        }

        private List<ProductEntity> ValidateProducts(List<ProductEntity> products)
        {
            ProductValidation productValidation = new ProductValidation(new RepositoryFactory<ProductEntity>(), ConnString);

            var allProducts = productValidation.GetAllProducts().ProductEntities;

            var totalPillCount = productValidation.CheckPillCount(products);

            if (totalPillCount > 38)
                return null;

            foreach (var product in products)
            {
                foreach (var productFromDb in allProducts)
                {
                    if (product.ProductName.Equals(productFromDb.ProductName))
                    {
                        
                    }
                } 
            }

            return null;

        }
    }
}