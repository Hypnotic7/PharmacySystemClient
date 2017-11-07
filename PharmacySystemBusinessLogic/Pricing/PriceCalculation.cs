using System;
using System.Collections.Generic;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemBusinessLogic.Pricing
{
    public class PriceCalculation
    {
        private List<ProductEntity> ProductEntities;
        private CustomerEntity CustomerEntity;

        public PriceCalculation(List<ProductEntity> productEntities, CustomerEntity customerEntity)
        {
            ProductEntities = productEntities;
            CustomerEntity = customerEntity;
        }

        public double CalculateTotalCostOfProducts()
        {
            var totalPriceForProducts = 0.0;

            foreach (var product in ProductEntities)
            {
                totalPriceForProducts += product.Quantity * product.Price;
            }

            return totalPriceForProducts;
        }

        public double CalculateDiscounts(double totalPriceForProducts)
        {
            var totalPrice = totalPriceForProducts;
            if (CustomerEntity.SchemesCards.DrugScheme)
            {
                if (totalPriceForProducts > 100)
                {
                   totalPrice -= Math.Round(totalPrice * .6, 2);
                }
            }
            else if(CustomerEntity.SchemesCards.MedicalCard)
            {
                return totalPrice = 0;
            }

            return totalPrice;
        }
    }
}
