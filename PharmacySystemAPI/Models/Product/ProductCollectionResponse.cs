using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemAPI.Models.Product
{
    public class ProductCollectionResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public IEnumerable<OrderEntity> ProductCollection { get; set; }
    }
}
