using Amazon.S3;
using Amazon.S3.Model;

namespace AWS.API.AWS
{
    public static class AWSSeeding
    {
        public static async Task SeedingData(this AmazonS3Client s3Client, Dictionary<string, string> shouldBuckets)
        {
            var currentBuckets = await s3Client.ListBucketsAsync();
            foreach (var shouldBucket in shouldBuckets)
            {
                var existBucket = currentBuckets.Buckets.Any(x => x.BucketName == shouldBucket.Key);
                if (existBucket)
                {
                    continue;
                }
                else
                {

                    s3Client.PutBucketAsync(new PutBucketRequest()
                    {
                        BucketName = shouldBucket.Key,
                        CannedACL = shouldBucket.Value
                    }).Wait();
                }
            }

        }
    }
}
