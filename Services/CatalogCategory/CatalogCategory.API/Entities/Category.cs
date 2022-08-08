using MongoDB.Bson.Serialization.Attributes;

namespace CatalogCategory.API.Entities
{
    public class Category : BaseEntity
    {
        [BsonRequired]
        public string CategoryName { get; set; }
    }
}
