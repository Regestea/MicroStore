using AWS.Application.Common.Interfaces;
using AWS.GRPC.Protos;
using Grpc.Core;

namespace AWS.GRPC.Services
{
    public class DeleteImageGrpcService : DeleteImageProtoService.DeleteImageProtoServiceBase
    {
        private IAWSFileRepository _fileRepository;

        public DeleteImageGrpcService(IAWSFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async override Task<DeleteImageResponse> DeleteImage(DeleteImageRequest request, ServerCallContext context)
        {
            var uploadedImageFilePath = request.ImagePath.Split("/");

            await _fileRepository.DeleteFile(uploadedImageFilePath[1], uploadedImageFilePath[2]);

            return new DeleteImageResponse() { };
        }
    }
}
