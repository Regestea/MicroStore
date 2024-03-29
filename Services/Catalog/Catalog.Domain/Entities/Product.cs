﻿using Catalog.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities
{
    public class Product : BaseEntity
    {
        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        public string BrandName { get; set; }

        [BsonRequired]
        public string BrandId { get; set; }

        public string Color { get; set; }

        public string HexColor { get; set; }

        [BsonRequired]
        public string CategoryName { get; set; }

        [BsonRequired]
        public string CategoryId { get; set; }

        [BsonRequired]
        public decimal Price { get; set; }

        public string OverView { get; set; }

        public List<ProductTechnicalDetail> TechnicalDetail { get; set; }

        public List<ProductPicture> Pictures { get; set; }
    }
}
