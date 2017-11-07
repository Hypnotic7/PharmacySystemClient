using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PharmacySystemDataAccess.Models.Account;
using PharmacySystemDataAccess.Models.Customer;
using PharmacySystemDataAccess.Models.Product;

namespace PharmacySystemDataAccess.Models.Order
{
    public class OrderEntity
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]

        public string OrderId { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public AccountEntity AccountEntity { get; set; }
        public List<ProductEntity> Products { get; set; }
        public double TotalCost;

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]

        public DateTime OrderDate{ get; set; }
        public FinalOrderType OrderType { get; set; }
        public List<string> Interceptions { get; set; }

    }

    public enum FinalOrderType
    {
        Rejected,
        Completed
    }
}
