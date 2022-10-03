using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities
{
    public class ProductPicture
    {
        [BsonRequired]
        public string ImagePath { get; set; }

    }
}
