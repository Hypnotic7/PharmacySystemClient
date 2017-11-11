using System.Collections.Generic;
using PharmacySystemBusinessLogic.Visitor;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemBusinessLogic.Product
{
    public class ProductValidation
    {
        public IDataAccessFindAll<ProductEntity> ProductRepository { get; }
        private List<IElement> containers { get; set; }

        public ProductValidation(IRepositoryFactory<ProductEntity> productFactory, string connectionString)
        {
            ProductRepository = (IDataAccessFindAll<ProductEntity>) productFactory.CreateRepository(connectionString, "ProductRepository");
            containers = new List<IElement>();
        }

        public ProductValidationStatus GetAllProducts()
        {
            var productValidationStatus = new ProductValidationStatus() { GotAllProducts = false,ProductEntities = new List<ProductEntity>()};

            var products = ProductRepository.FindAll();

            if (products.Count != 0)
            {
                return new ProductValidationStatus()
                {
                    GotAllProducts = true,
                    ProductEntities = products
                };
            }

            return new ProductValidationStatus();
        }


        public int CheckPillCount(List<ProductEntity> products)
        {
            foreach (var product in products)
            {
                
                if (product.Container.Equals("BlisterPack"))
                    containers.Add(new BlisterPackElement(product.Quantity));

                if (product.Container.Equals("bottle"))
                    containers.Add(new BottleElement(product.Quantity));
            }

            var weight = CalculateWeight(containers);
            return CalculateAmount(containers);
        }



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

        public bool CheckStock(List<ProductEntity> fullListOfProducts, List<ProductEntity> productListFromClient)
        {
            var inStock = false;
            foreach (var productFromFullList in fullListOfProducts)
            {
                foreach (var productFromClient in productListFromClient)
                {
                    if (productFromFullList.ProductName == productFromClient.ProductName)
                    {
                        inStock = productFromFullList.Quantity > productFromClient.Quantity;
                    }
                }
            }

            return inStock;
        }

        public bool ChangeQuantity(ProductEntity productEntity)
        {
            try
            {
                ProductRepository.Modify(productEntity);
            }
            catch (KeyNotFoundException e)
            {
                return false;
            }
            
            return true;
        }
    }
}
