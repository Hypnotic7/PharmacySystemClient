using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystemDataAccess.Models.Customer
{
    public class CustomerEntity
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public SchemesCards SchemesCards {get; set;}
    }
}
