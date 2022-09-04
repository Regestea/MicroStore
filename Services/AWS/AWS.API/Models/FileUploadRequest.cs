using AWS.API.Filters;
using System.ComponentModel.DataAnnotations;

namespace AWS.API.Models
{
    public class FileUploadRequest
    {
        [FileSizeKB(1, 5 * 1024)]
        [FileAllowedExtensions(".jpg", ".jpeg", ".png")]
        [Required]
        public IFormFile image { get; set; }
    }
}
