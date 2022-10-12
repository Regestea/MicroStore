using AWS.GRPC.Protos;

namespace Catalog.API.GrpcServices.AWS
{
    public class AwsGrpcService
    {
        private readonly DeleteImageProtoService.DeleteImageProtoServiceClient _deleteImageProtoServiceClient;

        public AwsGrpcService(DeleteImageProtoService.DeleteImageProtoServiceClient deleteImageProtoServiceClient)
        {
            _deleteImageProtoServiceClient = deleteImageProtoServiceClient;
        }

        public async Task DeleteImage(string imagePath)
        {
            await _deleteImageProtoServiceClient.DeleteImageAsync(new DeleteImageRequest() { ImagePath = imagePath });
        }
    }
}
