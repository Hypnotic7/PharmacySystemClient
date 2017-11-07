using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PharmacySystemDataAccess.Models.Account
{
    public class AccountEntity
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]

        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public bool IsLoggedIn { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LastLoginDate { get; set; }
    }

    public enum AccountTypeEnum
    {
        Admin,
        Manager,
        Employee
    }
}
