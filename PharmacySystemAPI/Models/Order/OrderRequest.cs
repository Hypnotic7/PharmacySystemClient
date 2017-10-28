using System.Collections.Generic;
using PharmacySystemAPI.Models.Product;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemAPI.Models.Order
{
    public class OrderRequest
    {
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public List<OrderEntity> CartItems { get; set; }
    }
}