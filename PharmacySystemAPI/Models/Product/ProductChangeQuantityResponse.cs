using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacySystemAPI.Models.Product
{
    public class ProductChangeQuantityResponse
    {
        public bool HasChanged { get; set; }
        public string Message { get; set; }
    }
}
