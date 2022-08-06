namespace Catalog.API.Entities
{
    public class Product : BaseEntity
    {
        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        public string BrandName { get; set; }

        public string Color { get; set; }

        public string HexColor { get; set; }

        [BsonRequired]
        public string CategoryName { get; set; }

        [BsonRequired]
        public string CategoryId { get; set; }

        [BsonRequired]
        public decimal Price { get; set; }

        public string OverView { get; set; }

        public List<TechnicalDetail> TechnicalDetail { get; set; }
    }

    public class TechnicalDetail
    {
        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        public string Description { get; set; }
    }
}
