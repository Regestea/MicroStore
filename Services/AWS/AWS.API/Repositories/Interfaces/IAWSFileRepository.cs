using Amazon.S3;
using AWS.API.DTOs.Responses;
using AWS.API.Globals;

namespace AWS.API.Repositories.Interfaces
{
    public interface IAWSFileRepository
    {
        Task<UploadFilesResponse> UploadFiles(Buckets.Names bucketCategory, Guid objectOwnerId, IList<IFormFile> files, S3CannedACL acl);
        Task<UploadFileResponse> UploadFile(Buckets.Names bucketCategory, Guid objectOwnerId, IFormFile file, S3CannedACL acl);
        Task<DeleteFileResponse> DeleteFile(Buckets.Names bucketCategory, Guid objectOwnerId, Guid fileName);
    }
}
