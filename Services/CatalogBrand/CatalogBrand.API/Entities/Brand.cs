using MongoDB.Bson.Serialization.Attributes;

namespace CatalogBrand.API.Entities
{
    public class Brand : BaseEntity
    {
        [BsonRequired]
        public string CategoryName { get; set; }
        [BsonRequired]
        public string CategoryId { get; set; }
        [BsonRequired]
        public string BrandName { get; set; }
    }
}
