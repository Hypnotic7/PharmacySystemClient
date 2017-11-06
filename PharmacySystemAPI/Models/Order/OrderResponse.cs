using PharmacySystemDataAccess.Models.Order;

namespace PharmacySystemAPI.Models.Order
{
    public class OrderResponse
    {
        public bool OrderComplete { get; set; }
        public string Message { get; set; }
        public OrderEntity OrderEntity { get; set; }
    }
}