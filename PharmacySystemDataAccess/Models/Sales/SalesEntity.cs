using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystemDataAccess.Models.Sales
{
    public class SalesEntity
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SalesId { get; set; }
        public int RegularSales { get; set; }
        public int MedicalCardSales { get; set; }
        public int DrugSchemeSales { get; set; }
    }
}