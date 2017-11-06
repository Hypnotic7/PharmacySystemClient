using System.Collections.Generic;
using PharmacySystemBusinessLogic.RepositoryFactory;
using PharmacySystemBusinessLogic.Visitor;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository;

namespace PharmacySystemBusinessLogic.Product
{
    public class ProductValidation
    {
        public IDataAccessFindAll<ProductEntity> ProductRepository { get; }
        private List<IElement> containers { get; set; }

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


        //public QuantityDetails CheckAmountOfContainer(string container)
        //{
        //    if(totalPillsInPack != null)
        //            var totalPills = CalculateAmount(containers);
        //    if (totalWeightOfBottle != null)
        //    {
                
        //    }
        //            var totalWeight = CalculateWeight(containers);
            
            


        //    return true;
        //}



        private double CalculateWeight(List<IElement> productsC)
        {
            var visitor = new PillWeightVisitor();

            //iterate through each item in list
            foreach (IElement e in productsC)
            {
                e.Accept(visitor);
            }

            return visitor._weight;
        }


        private int CalculateAmount(List<IElement> productsB)
        {
            var visitor = new PillCountVisitor();

            //iterate through each item in list
            foreach (IElement e in productsB)
            {
                e.Accept(visitor);
            }

            return visitor._count;
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
