using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using PharmacySystemBusinessLogic.Account.Validation;
using PharmacySystemBusinessLogic.Customer;
using PharmacySystemBusinessLogic.Pricing;
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

            if (ValidateProducts(products))
            {
                PriceCalculation pricing = new PriceCalculation(products,customer);
                var totalCost = pricing.CalculateTotalCostOfProducts();
                totalCost = pricing.CalculateDiscounts(totalCost);

                orderValidationStatus.IsValid = true;
                orderValidationStatus.OrderEntity = new OrderEntity()
                {
                    CustomerEntity = customer,
                    AccountEntity = account,
                    OrderDate = DateTime.Now,
                    OrderId = ObjectId.GenerateNewId().ToString(),
                    OrderType = FinalOrderType.Completed,
                    Products = products,
                    TotalCost = totalCost
                };

                return orderValidationStatus;
            }
            return orderValidationStatus;
        }

        public bool AddOrderToRepository(OrderEntity orderEntity)
        {
            try
            {
                OrderRepository.Add(orderEntity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
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

        private bool ValidateProducts(List<ProductEntity> products)
        {
            ProductValidation productValidation = new ProductValidation(new RepositoryFactory<ProductEntity>(), ConnString);

            var allProducts = productValidation.GetAllProducts().ProductEntities;

            var totalPillCount = productValidation.CheckPillCount(products);

            if (totalPillCount > 38)
                return false;

            var inStock = productValidation.CheckStock(allProducts, products);

            var quantityChanged = false;
            if (inStock)
            {

                foreach (var product in products)
                    quantityChanged = productValidation.ChangeQuantity(product);
            }
            return quantityChanged;

        }
    }
}