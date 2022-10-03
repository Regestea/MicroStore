using MongoDB.Driver;

namespace Catalog.Infrastructure.Common.Extensions
{
    public static class PaginationExtension
    {
        public static IFindFluent<BaseEntity, BaseEntity> Paginate<BaseEntity>(this IFindFluent<BaseEntity, BaseEntity> findFluent, int currentPage, int itemInPage)
        {
            return findFluent.Skip((currentPage - 1) * itemInPage).Limit(itemInPage);
        }
    }
}
