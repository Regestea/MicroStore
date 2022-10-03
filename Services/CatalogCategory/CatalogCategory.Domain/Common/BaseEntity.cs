using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogCategory.Domain.Common
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            if (CreatedDate == null) CreatedDate = DateTimeOffset.UtcNow;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
