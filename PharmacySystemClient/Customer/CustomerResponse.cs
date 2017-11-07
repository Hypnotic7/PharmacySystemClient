using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient
{
    class CustomerResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public PrescriptionEntity PrescriptionEntity { get; set; }
    }
}
