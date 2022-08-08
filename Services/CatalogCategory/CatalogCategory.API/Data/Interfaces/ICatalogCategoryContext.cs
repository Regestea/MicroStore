using CatalogCategory.API.Entities;
using MongoDB.Driver;

namespace CatalogCategory.API.Data.Interfaces
{
    public interface ICatalogCategoryContext
    {
        IMongoCollection<Category> Categories { get; }
    }
}