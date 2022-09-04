namespace AWS.API.DTOs.Responses
{
    public class UploadFileResponse
    {
        public Guid objectOwnerId { get; set; }
        public string BucketName { get; set; }
        public Guid FileName { get; set; }
        public string Format { get; set; }
    }
}
