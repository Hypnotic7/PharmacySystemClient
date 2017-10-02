using System;
using System.Reflection.Metadata;

namespace PharmacySystemDataAccess.Models.Customer
{
    public class CustomerEntity
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public bool MedicalCard { get; set; }
        public bool DrugScheme { get; set; }
    }
}
