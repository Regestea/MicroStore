using Amazon.S3;

namespace AWS.Application.Common.Interfaces
{
    public interface IAmazonS3ClientContext
    {
        public AmazonS3Client S3 { get; set; }
    }
}
