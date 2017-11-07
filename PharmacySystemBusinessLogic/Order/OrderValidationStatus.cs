using PharmacySystemDataAccess.Models.Order;

namespace PharmacySystemBusinessLogic.Order
{
    public class OrderValidationStatus
    {
        public bool IsValid { get; set; }
        public OrderEntity OrderEntity { get; set; }
    }
}