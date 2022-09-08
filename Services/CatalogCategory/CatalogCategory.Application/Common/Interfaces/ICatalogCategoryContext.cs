using CatalogCategory.Domain.Entities;
using MongoDB.Driver;

namespace CatalogCategory.Application.Common.Interfaces
{
    public interface ICatalogCategoryContext
    {
        IMongoCollection<Category> Categories { get; }
    }
}