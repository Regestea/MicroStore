﻿using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CatalogComment.API.Entities
{
    public class Comment : BaseEntity
    {
        [BsonRequired]
        public string UserId { get; set; }

        [BsonRequired]
        [MaxLength(200)]
        public string UserComment { get; set; }

        [BsonRequired]
        public string ProductId { get; set; }
    }
}
