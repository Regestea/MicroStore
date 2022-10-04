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
            return new ExistUserResponse() { Exist = await _UserRepository.IsUserExistAsync(request.UserId) };
        }

        public override async Task<ChangeProfileImageResponse> ChangeProfileImage(ChangeProfileImageRequest request, ServerCallContext context)
        {
            bool isAdded = await _UserRepository.ChangeProfileImageAsync(request.UserId, request.FilePath);

            return new ChangeProfileImageResponse() { IsAdded = isAdded };
        }

    }
}
