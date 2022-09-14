using Amazon.S3;
using AWS.Application.Common.Globals;
using Microsoft.AspNetCore.Http;

namespace AWS.Application.Common.Interfaces
{
    public interface IAWSFileRepository
    {
        Task<string> UploadFile(Buckets.Names bucketCategory, IFormFile file, S3CannedACL acl);
        Task DeleteFile(Buckets.Names bucketCategory, Guid fileName);
    }
}
