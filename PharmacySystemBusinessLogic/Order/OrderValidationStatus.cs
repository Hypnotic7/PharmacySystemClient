using System.Collections.Generic;
using PharmacySystemDataAccess.Models.Order;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemBusinessLogic.Order
{
    public class OrderValidationStatus
    {
        public bool IsValid { get; set; }
        public OrderEntity OrderEntity { get; set; }

    }
}