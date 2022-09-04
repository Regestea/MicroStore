namespace AWS.API.DTOs.Responses
{
    public class DeleteFileResponse
    {
        public Guid objectOwnerId { get; set; }
        public string BucketName { get; set; }
        public Guid FileName { get; set; }
    }
}
