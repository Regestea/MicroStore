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


    }
}
