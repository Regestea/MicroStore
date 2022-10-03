using Grpc.Core;
using UserAccount.Application.Common.Interfaces;
using UserAccount.GRPC.Protos;

namespace UserAccount.GRPC.Services
{
    public class UserGrpcServices : UserProtoService.UserProtoServiceBase
    {
        private IUserRepository _UserRepository;

        public UserGrpcServices(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public override async Task<ExistUserResponse> ExistUser(ExistUserRequest request, ServerCallContext context)
        {
            return new ExistUserResponse() { Exist = await _UserRepository.IsUserExist(request.UserId) };
        }

        public override async Task<AddImageResponse> AddImage(AddImageRequest request, ServerCallContext context)
        {
            bool isAdded = await _UserRepository.AddUserImage(request.UserId, request.FilePath);

            return new AddImageResponse() { IsAdded = isAdded };
        }

        public override async Task<EditImageResponse> EditImage(EditImageRequest request, ServerCallContext context)
        {
            bool isEdited = await _UserRepository.EditUserImage(request.UserId, request.NewFilePath);

            return new EditImageResponse() { IsEdited = isEdited };
        }
    }
}
