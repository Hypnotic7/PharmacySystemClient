using System;
using System.Collections.Generic;
using MongoDB.Bson;
using PharmacySystemBusinessLogic.Account.Validation;
using PharmacySystemBusinessLogic.Customer;
using PharmacySystemBusinessLogic.Pricing;
using PharmacySystemBusinessLogic.Interceptor;
using PharmacySystemBusinessLogic.Product;
using PharmacySystemBusinessLogic.Sales;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Models.Sales;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Order
{
    public class OrderValidation
    {
        public IDataAccess<OrderEntity> OrderRepository { get; }
        public string ConnString { private set; get; }
        private ILogger logger;
        private IInvoker invoker;
        private Dispatcher dispatcher;

        public OrderValidation(IRepositoryFactory<OrderEntity> orderFactory, string connectionString, Dispatcher dispatcher, ILogger logger, IInvoker invoker)
        {
            ConnString = connectionString;
            OrderRepository = orderFactory.CreateRepository(ConnString, "OrderRepository");
            this.logger = logger;
            this.invoker = invoker;
            this.dispatcher = dispatcher;
        }

        public OrderValidationStatus ValidateOrder(string accName,string custName, List<ProductEntity> products)
        {
            logger.Message = "Starting Validation On Order";
            dispatcher.interceptors.ForEach(f => f.Intercept(logger));

            var orderValidationStatus = new OrderValidationStatus() {IsValid = false};

            if (accName.Equals(null) || custName.Equals(null) || products.Equals(null)) return orderValidationStatus;

            var accountName = accName.Trim();
            var customerName = custName.Trim();

            logger.Message = "Validate Account";
            dispatcher.interceptors.ForEach(f => f.Intercept(logger));
            invoker.Message = "ValidateAccountEntity()";
            dispatcher.interceptorsInv.ForEach(f => f.Intercept(invoker));
            var account = ValidateAccountEntity(accountName);

            if (account == null)
                return orderValidationStatus;

            logger.Message = "Validate Customer";
            dispatcher.interceptors.ForEach(f => f.Intercept(logger));

            var customer = ValidateCustomerEntity(customerName);

            if (customer == null)
                return orderValidationStatus;

            logger.Message = "Validate Products";
            dispatcher.interceptors.ForEach(f => f.Intercept(logger));

            if (ValidateProducts(products))
            {
                PriceCalculation pricing = new PriceCalculation(products,customer);
                logger.Message = "Calculating Total Price For Products";
                dispatcher.interceptors.ForEach(f => f.Intercept(logger));
                var totalCost = pricing.CalculateTotalCostOfProducts();
                logger.Message = ("Calculating Discounts");
                dispatcher.interceptors.ForEach(f => f.Intercept(logger));
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
                    TotalCost = totalCost,
                    Interceptions = logger.LogList,
                    Invokations = invoker.InvokedList
                };

                SalesValidation salesValidation = new SalesValidation(new RepositoryFactory<SalesEntity>(), ConnString);
                var salesEntity = salesValidation.GetAllSales();

                if (orderValidationStatus.OrderEntity.CustomerEntity.SchemesCards.DrugScheme)
                    salesEntity.SalesEntity.DrugSchemeSales++;

                else if (orderValidationStatus.OrderEntity.CustomerEntity.SchemesCards.MedicalCard)
                    salesEntity.SalesEntity.MedicalCardSales++;

                else
                    salesEntity.SalesEntity.RegularSales++;

                salesValidation.UpdateSales(salesEntity.SalesEntity);

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