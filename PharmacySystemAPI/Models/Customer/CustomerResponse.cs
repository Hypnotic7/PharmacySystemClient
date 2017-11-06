using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Models.Prescription;

namespace PharmacySystemAPI.Models.Customer
{
    public class CustomerResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public PrescriptionEntity PrescriptionEntity { get; set; }
    }
}
