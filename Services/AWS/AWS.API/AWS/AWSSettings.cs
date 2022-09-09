namespace AWS.API.AWS
{
    public interface IAWSSettings
    {
        string ServiceURL { get; set; }
        string AccessKey { get; set; }
        string SecretKey { get; set; }
        Dictionary<string, string> Buckets { get; set; }

    }

    public class AWSSettings : IAWSSettings
    {
        public string ServiceURL { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public Dictionary<string, string> Buckets { get; set; }
    }
}