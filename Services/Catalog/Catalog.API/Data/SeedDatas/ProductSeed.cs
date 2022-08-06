using Catalog.API.Entities;

namespace Catalog.API.Data.SeedDatas
{
    public class ProductSeed
    {
        public static List<Product> Get()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    CategoryName = "hello",
                    Title ="gggd",
                    TechnicalDetail = new List<TechnicalDetail>(){new TechnicalDetail()
                    {
                        Description = "dis good",
                        Title = "titledisgood"
                    }}
                }
            };
        }
    }
}
