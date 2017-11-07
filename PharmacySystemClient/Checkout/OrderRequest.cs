using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient.Checkout
{
    class OrderRequest
    {
        public string AccountName { get; set; }
        public string CustomerName { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
