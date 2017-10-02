using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacySystemAPI.Models.Product;
using PharmacySystemBusinessLogic.Product;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController
    {

        // GET api/values
        [HttpGet]
        public ProductCollectionResponse GetProductCollection()
        {
            ProductValidation product;
            return new ProductCollectionResponse();
        }

        [HttpPost]
        public ProductCheckQuantityResponse CheckQuantity([FromBody] ProductCheckQuantityRequest productRequest)
        {
            return new ProductCheckQuantityResponse();
        }

        [HttpPost]
        public ProductChangeQuantityResponse ChangeQuantity([FromBody] ProductChangeQuantityRequest productRequest)
        {
            return new ProductChangeQuantityResponse();
        }


    }
}
