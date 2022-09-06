using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using AWS.API.DTOs.Responses;
using AWS.API.Globals;
using AWS.API.Repositories.Interfaces;

namespace AWS.API.Repositories
{
    public class AWSFileRepository : IAWSFileRepository
    {
        private AmazonS3Client _S3client;

        public AWSFileRepository(AmazonS3Client s3Client)
        {
            _S3client = s3Client;
        }


        public async Task<UploadFileResponse> UploadFile(Buckets.Names bucketCategory, Guid objectOwnerId, IFormFile file, S3CannedACL acl)
        {
            var response = new UploadFileResponse() { ObjectOwnerId = objectOwnerId };

            using var fileTransferUtility = new TransferUtility(_S3client);

            await using Stream fileStream = file.OpenReadStream();

            var key = Guid.NewGuid();
            var req = new TransferUtilityUploadRequest
            {
                BucketName = bucketCategory.ToString(),
                Key = key.ToString(),
                InputStream = fileStream,
                AutoCloseStream = false,
                AutoResetStreamPosition = true,
                CannedACL = acl
            };

            await fileTransferUtility.UploadAsync(req);

            response.FilePath = @"/" + bucketCategory + "/" + key;


            return response;
        }

        public async Task<DeleteFileResponse> DeleteFile(Buckets.Names bucketCategory, Guid objectOwnerId, Guid fileName)
        {
            var req = new DeleteObjectRequest()
            {
                BucketName = bucketCategory.ToString(),
                Key = fileName.ToString()
            };
            await _S3client.DeleteObjectAsync(req);

            var response = new DeleteFileResponse()
            {
                objectOwnerId = objectOwnerId,
                FilePath = @"/" + bucketCategory + "/" + fileName
            };

            return response;
        }

    }
}
