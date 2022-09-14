using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace AWS.Infrastructure.Persistence.AWS
{

    public static class AWSSeeding
    {

        public static async Task SeedingData(this AmazonS3Client _S3client, Dictionary<string, string> shouldBuckets)
        {
            var currentBuckets = await _S3client.ListBucketsAsync();

            foreach (var shouldBucket in shouldBuckets)
            {
                var existBucket = currentBuckets.Buckets.Any(x => x.BucketName == shouldBucket.Key);
                if (existBucket)
                {
                    continue;
                }
                else
                {
                    _S3client.PutBucketAsync(new PutBucketRequest()
                    {
                        BucketName = shouldBucket.Key,
                        CannedACL = shouldBucket.Value
                    }).Wait();
                }
            }

            var bucketList = await _S3client.ListBucketsAsync();

            foreach (var bucket in bucketList.Buckets)
            {
                try
                {
                    var response = await _S3client.GetObjectMetadataAsync(new GetObjectMetadataRequest() { BucketName = bucket.BucketName, Key = "Default" });
                }

                catch (Amazon.S3.AmazonS3Exception ex)
                {
                    if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        using var fileTransferUtility = new TransferUtility(_S3client);

                        string targetPath = Directory.GetCurrentDirectory();

                        targetPath = Path.Combine(targetPath, "wwwroot/DefaultImages/" + bucket.BucketName + "/Default.jpg");

                        await using var imageFileStream = File.OpenRead(targetPath);

                        var req = new TransferUtilityUploadRequest
                        {
                            BucketName = bucket.BucketName,
                            Key = "Default",
                            InputStream = imageFileStream,
                            AutoCloseStream = true,
                            AutoResetStreamPosition = true,
                            CannedACL = S3CannedACL.PublicRead
                        };

                        await fileTransferUtility.UploadAsync(req);
                    }
                }
            }
        }
    }
}
