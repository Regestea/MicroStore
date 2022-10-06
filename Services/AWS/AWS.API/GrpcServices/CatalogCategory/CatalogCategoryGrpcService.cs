using CatalogCategory.GRPC.Protos;

namespace AWS.API.GrpcServices.CatalogCategory
{
    public class CatalogCategoryGrpcService
    {
        private CatalogCategoryProtoService.CatalogCategoryProtoServiceClient _catalogCategoryProtoService;

        public CatalogCategoryGrpcService(CatalogCategoryProtoService.CatalogCategoryProtoServiceClient catalogCategoryProtoService)
        {
            _catalogCategoryProtoService = catalogCategoryProtoService;
        }

        public async Task<bool> ExistCatalogCategoryAsync(string catalogCategoryId)
        {
            var existCatalogCategory = await _catalogCategoryProtoService.ExistCatalogCategoryAsync(new ExistCatalogCategoryRequest() { CatalogCategoryId = catalogCategoryId });

            return existCatalogCategory.Exist;
        }

        public async Task<ChangeCatalogCategoryImagePathResponse> ChangeCatalogCategoryImagePathAsync(string catalogCategoryId, string imagePath)
        {
            var addImageResponse = await _catalogCategoryProtoService.ChangeCatalogCategoryImagePathAsync(
                new ChangeCatalogCategoryImagePathRequest()
                {
                    ImagePath = imagePath,
                    CatalogCategoryId = catalogCategoryId
                });

            return addImageResponse;
        }
    }
}
