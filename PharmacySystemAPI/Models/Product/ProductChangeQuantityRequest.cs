using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacySystemAPI.Models.Product
{
    public class ProductChangeQuantityRequest
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
