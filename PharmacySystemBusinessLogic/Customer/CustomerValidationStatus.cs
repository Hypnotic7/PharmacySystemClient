using PharmacySystemDataAccess.Models.Customer;

namespace PharmacySystemBusinessLogic.Customer
{
    public class CustomerValidationStatus
    {
        public bool IsValid { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
    }
}
