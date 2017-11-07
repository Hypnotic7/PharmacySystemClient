using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacySystemClient.Orders;

namespace PharmacySystemClient
{
    class CustomerEntity
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public SchemesCards SchemesCards { get; set; }
    }
}
