using CatalogCategory.Application.Common.Interfaces;
using CatalogCategory.GRPC.Protos;
using Grpc.Core;

namespace CatalogCategory.GRPC.Services
{
    public class CatalogCategoryGrpcService : CatalogCategoryProtoService.CatalogCategoryProtoServiceBase
    {
        private ICatalogCategoryRepository _catalogCategoryRepository;

        public CatalogCategoryGrpcService(ICatalogCategoryRepository catalogCategoryRepository)
        {
            _catalogCategoryRepository = catalogCategoryRepository;
        }

        public override async Task<ExistCatalogCategoryResponse> ExistCatalogCategory(ExistCatalogCategoryRequest request, ServerCallContext context)
        {
            bool existCatalogCategory = await _catalogCategoryRepository.ExistCatalogCategory(request.CatalogCategoryId);

            return new ExistCatalogCategoryResponse() { Exist = existCatalogCategory };
        }

        public override async Task<AddImageToCatalogCategoryResponse> AddImageToCatalogCategory(AddImageToCatalogCategoryRequest request, ServerCallContext context)
        {
            var isSucceeded = await _catalogCategoryRepository.AddImagePath(request.CatalogCategoryId, request.ImagePath);

            return new AddImageToCatalogCategoryResponse() { IsAdded = isSucceeded };
        }
    }
}
