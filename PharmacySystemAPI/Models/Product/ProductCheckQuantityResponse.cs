using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacySystemAPI.Models.Product
{
    public class ProductCheckQuantityResponse
    {
        public bool IsInStock { get; set; }
        public string Message { get; set; }
    }
}
