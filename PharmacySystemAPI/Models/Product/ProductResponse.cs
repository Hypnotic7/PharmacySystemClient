using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemAPI.Models.Product
{
    public class ProductResponse
    {
        public List<ProductEntity> ProductEntities;
        public string Message;
    }
}
