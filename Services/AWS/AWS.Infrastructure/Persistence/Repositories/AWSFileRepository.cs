using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using AWS.Application.Common.Globals;
using AWS.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AWS.Infrastructure.Persistence.Repositories
{
    public class AWSFileRepository : IAWSFileRepository
    {
        private IAmazonS3ClientContext _amazonS3ClientContext;

        public AWSFileRepository(IAmazonS3ClientContext amazonS3ClientContext)
        {
            _amazonS3ClientContext = amazonS3ClientContext;
        }


        public async Task<string> UploadFile(Buckets.Names bucketCategory, IFormFile file, S3CannedACL acl)
        {

            using var fileTransferUtility = new TransferUtility(_amazonS3ClientContext.S3);

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

            string filePath = @"/" + bucketCategory + "/" + key;


            return filePath;
        }

        public async Task DeleteFile(Buckets.Names bucketCategory, Guid fileName)
        {
            var req = new DeleteObjectRequest()
            {
                BucketName = bucketCategory.ToString(),
                Key = fileName.ToString()
            };
            await _amazonS3ClientContext.S3.DeleteObjectAsync(req);
        }

    }
}
