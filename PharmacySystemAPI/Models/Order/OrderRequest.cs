using System.Collections.Generic;
using PharmacySystemAPI.Models.Product;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemAPI.Models.Order
{
    public class OrderRequest
    {
        public string AccountName { get; set; }
        public string CustomerName { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}