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

        public async Task<bool> AddImageToUserAccountAsync(string userId, string filePath)
        {
            var request = new AddImageRequest() { UserId = userId, FilePath = filePath };

            var result = await _userProtoService.AddImageAsync(request);

            return result.IsAdded;
        }

        public async Task<bool> EditUserAccountImageAsync(string userId, string filePath)
        {
            var request = new EditImageRequest() { UserId = userId, NewFilePath = filePath };

            var result = await _userProtoService.EditImageAsync(request);

            return result.IsEdited;
        }


    }
}
