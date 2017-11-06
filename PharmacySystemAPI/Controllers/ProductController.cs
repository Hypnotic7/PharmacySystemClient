using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PharmacySystemAPI.Models.Product;
using PharmacySystemBusinessLogic.Product;
using PharmacySystemDataAccess.Models.Product;
using PharmacySystemDataAccess.Repository.RepositoryFactory;

namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController
    {
        private IOptions<AppSettings> _appSettings;

        public ProductController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }


        // GET api/values
        [HttpGet]
        public ProductResponse GetProducts()
        {
            ProductValidation productValidation = new ProductValidation(new RepositoryFactory<ProductEntity>(), _appSettings.Value.MongoConnectionString);

            try
            {
                var productValidationStatus = productValidation.GetAllProducts();
                return new ProductResponse()
                {
                    Message = "JUPI",
                    ProductEntities = productValidationStatus.ProductEntities
                };
            }
            catch (KeyNotFoundException keyNotFound)
            {
                return new ProductResponse()
                {
                    Message = keyNotFound.Message,
                    ProductEntities = null
                };

            }
            
        }


    }
}
