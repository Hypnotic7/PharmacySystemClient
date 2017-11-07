using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient.Checkout
{
    class OrderResponse
    {
        public bool OrderComplete { get; set; }
        public string Message { get; set; }
        public OrderEntity OrderEntity { get; set; }
    }
}
