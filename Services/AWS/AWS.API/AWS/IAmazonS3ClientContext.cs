using Amazon.S3;

namespace AWS.API.AWS
{
    public interface IAmazonS3ClientContext
    {
        public AmazonS3Client S3 { get; set; }
    }
}
