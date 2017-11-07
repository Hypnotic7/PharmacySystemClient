using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystemDataAccess.Models.Prescription
{
    public class PrescriptionEntity
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]

        public string PrescriptionId { get; set; }
        public string CustomerName { get; set; }
        public string GpName { get; set; }
        public string Products  { get; set; }
    }
}
