using CatalogCategory.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogCategory.Domain.Entities
{
    public class Category : BaseEntity
    {
        [BsonRequired]
        public string CategoryName { get; set; }

        public string Image { get; set; }
    }
}
