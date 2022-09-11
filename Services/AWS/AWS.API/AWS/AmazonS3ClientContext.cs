using Amazon.S3;

namespace AWS.API.AWS
{
    public class AmazonS3ClientContext : IAmazonS3ClientContext
    {

        public AmazonS3ClientContext(IConfiguration configuration)
        {
            var awsConfig = configuration.GetSection(nameof(AWSSettings));
            var awsSettings = awsConfig.Get<AWSSettings>();
            var s3Config = new AmazonS3Config
            {
                ServiceURL = awsSettings.ServiceURL,
                MaxErrorRetry = 3,
                ForcePathStyle = true
            };

            S3 = new AmazonS3Client(awsSettings.AccessKey, awsSettings.SecretKey, s3Config);

            S3.SeedingData(awsSettings.Buckets).Wait();
        }


        public AmazonS3Client S3 { get; set; }
    }
}
