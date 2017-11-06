using System;
using System.Collections.Generic;
using System.Text;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemBusinessLogic.Product
{
    public class ProductValidationStatus
    {
        public bool GotAllProducts { get; set; }
        public List<ProductEntity> ProductEntities { get; set; }
    }
}
