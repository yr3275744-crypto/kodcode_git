using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace products_api.Models
{
    public class Producte
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public double price { get; set; }
        public int stock { get; set; }
        public double rating { get; set; }
        public bool isActive { get; set; }
        public DateTime createdAt { get; set; }
    }
}

