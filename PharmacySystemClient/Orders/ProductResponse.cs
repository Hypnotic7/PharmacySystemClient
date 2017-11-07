using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient.Orders
{
    class ProductResponse
    {
        public bool GotAllProducts { get; set; }
        public List<ProductEntity> ProductEntities { get; set; }
    }
}
