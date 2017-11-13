using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacySystemClient.Accounts;
using PharmacySystemClient.Orders;

namespace PharmacySystemClient.Checkout
{
    class OrderEntity
    {
        public string OrderId { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public AccountEntity AccountEntity { get; set; }
        public List<ProductEntity> Products { get; set; }
        public double TotalCost;
        public DateTime OrderDate { get; set; }
        public FinalOrderType OrderType { get; set; }
        public List<string> Interceptions { get; set; }
    }
    public enum FinalOrderType
    {
        Rejected,
        Completed
    }
}
