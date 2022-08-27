using UserAccount.GRPC.Protos;

namespace CatalogComment.API.GrpcServices
{
    public class UserGrpcService
    {
        private readonly UserProtoService.UserProtoServiceClient _userProtoService;

        public UserGrpcService(UserProtoService.UserProtoServiceClient userProtoService)
        {
            _userProtoService = userProtoService;
        }

        public async Task<bool> ExistUserAsync(string UserId)
        {
            var UserRequest = new ExistUserRequest() { UserId = UserId };
            var userResponse = await _userProtoService.ExistUserAsync(UserRequest);
            return userResponse.Exist;
        }
    }
}
