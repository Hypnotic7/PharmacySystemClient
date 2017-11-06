using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemBusinessLogic.Order
{
    public class OrderValidationStatus
    {
        public bool IsValid { get; set; }
        public ProductEntity Product { get; set; }
    }
}