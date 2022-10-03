namespace Catalog.Application.Common.DTOs
{
    public class ProductDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string BrandName { get; set; }

        public string BrandId { get; set; }

        public string Color { get; set; }

        public string HexColor { get; set; }

        public string CategoryName { get; set; }

        public string CategoryId { get; set; }

        public decimal Price { get; set; }

        public string OverView { get; set; }

        public string ImageTitleUrl
        {
            get { return Globals.Url.AWSServerAddress + (Pictures[0].ImagePath ?? "/product/Default"); }
        }

        public List<ProductTechnicalDetailDTO> TechnicalDetail { get; set; }

        public List<ProductPictureDTO> Pictures { get; set; }
    }
}
