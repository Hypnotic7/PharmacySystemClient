using System.Collections.Generic;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemAPI.Models.Product
{
    public class ProductResponse
    {
        public List<ProductEntity> ProductEntities;
        public string Message;
    }
}
