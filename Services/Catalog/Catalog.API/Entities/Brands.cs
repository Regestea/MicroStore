using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Brands : BaseEntity
    {
        [BsonRequired]
        public string CategoryName { get; set; }
        [BsonRequired]
        public string CategoryId { get; set; }
        [BsonRequired]
        public string BrandName { get; set; }
    }
}
