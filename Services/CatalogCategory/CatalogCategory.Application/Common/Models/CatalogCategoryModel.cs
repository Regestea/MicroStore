namespace CatalogCategory.Application.Common.Models
{
    public class CatalogCategoryModel
    {
        public string Id { get; set; }

        public string CategoryName { get; set; }

        public string Image { get; set; }

        public string ImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(Image))
                {
                    return (Globals.Url.AWSServerAddress + Image);
                }
                return (Globals.Url.AWSServerAddress + "/microstorecategory/Default");
            }
        }
    }
}
