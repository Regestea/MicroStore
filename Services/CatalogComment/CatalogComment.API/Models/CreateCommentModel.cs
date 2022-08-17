using MongoDB.Bson.Serialization.Attributes;

namespace CatalogComment.API.Models
{
    public class CreateCommentModel
    {
        [BsonRequired]
        public string UserId { get; set; }

        [BsonRequired]
        public string UserComment { get; set; }

        [BsonRequired]
        public string ProductId { get; set; }
    }
}
