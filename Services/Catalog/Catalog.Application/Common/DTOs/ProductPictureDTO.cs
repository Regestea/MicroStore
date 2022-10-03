namespace Catalog.Application.Common.DTOs
{
    public class ProductPictureDTO
    {
        public string? ImagePath { get; set; }

        public string? ImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(ImagePath))
                {
                    return Globals.Url.AWSServerAddress + ImagePath;
                }

                return null;
            }
        }
    }
}
