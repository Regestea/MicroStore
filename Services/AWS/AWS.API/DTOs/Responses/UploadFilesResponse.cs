namespace AWS.API.DTOs.Responses
{
    public class UploadFilesResponse
    {
        public Guid objectOwnerId { get; set; }
        public string BucketName { get; set; }
        public List<ObjectUpload> FileList { get; set; }
    }

    public class ObjectUpload
    {
        public Guid FileName { get; set; }
        public string Format { get; set; }
    }
}
