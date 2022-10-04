using UserAccount.GRPC.Protos;

namespace AWS.API.GrpcServices.UserAccount
{
    public class UserAccountGrpcService
    {
        private UserProtoService.UserProtoServiceClient _userProtoService;

        public UserAccountGrpcService(UserProtoService.UserProtoServiceClient userProtoService)
        {
            _userProtoService = userProtoService;
        }

        public async Task<bool> ExistUserAccountAsync(string userId)
        {
            var request = new ExistUserRequest() { UserId = userId };

            var result = await _userProtoService.ExistUserAsync(request);

            return result.Exist;
        }

        public async Task<bool> ChangeProfileImageAsync(string userId, string filePath)
        {
            var request = new ChangeProfileImageRequest() { UserId = userId, FilePath = filePath };

            var result = await _userProtoService.ChangeProfileImageAsync(request);

            return result.IsAdded;
        }

    }
}
