using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities
{
    public class ProductTechnicalDetail
    {
        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        public string Description { get; set; }
    }
}
