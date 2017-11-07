using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient
{
    class ProductEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool RequiresPrescription { get; set; }
        public string Container { get; set; }
    }
}
