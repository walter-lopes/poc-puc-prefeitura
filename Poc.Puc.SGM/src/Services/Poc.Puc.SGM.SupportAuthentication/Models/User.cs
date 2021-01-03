using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAppAuthenticationSGM.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}
        public string Login {get;set;}
        public string Password {get;set;}
        public string Role {get;set;}
        public string Name { get; set; }
        public string Token { get; set; }
    }
}