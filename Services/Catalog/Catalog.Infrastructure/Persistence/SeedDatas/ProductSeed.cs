using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Persistence.SeedDatas
{
    public class ProductSeed
    {
        public static List<Product> Get()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "62eff26faa2a7d20bc66fb8e",
                    CategoryName = "hello",
                    Title ="gggd",
                    TechnicalDetail = new List<ProductTechnicalDetail>(){new ProductTechnicalDetail()
                    {
                        Description = "dis good",
                        Title = "titledisgood"
                    }},
                    Pictures = new List<ProductPicture>()
                },
                new Product()
                {
                    Id = "62eff28e6d75d45a6581e289",
                    CategoryName = "hello2",
                    Title ="gggd2",
                    TechnicalDetail = new List<ProductTechnicalDetail>(){new ProductTechnicalDetail()
                    {
                        Description = "dis good2",
                        Title = "titledisgood2"
                    }},
                    Pictures = new List<ProductPicture>()
                }
            };
        }
    }
}
