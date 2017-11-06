using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemBusinessLogic.Order
{
    public class ProductValidationStatus
    {
        public bool IsValid { get; set; }
        public ProductEntity Product { get; set; }
    }
}