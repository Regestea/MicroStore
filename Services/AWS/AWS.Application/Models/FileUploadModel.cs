using AWS.Application.Common.Filters;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AWS.Application.Models
{
    public class FileUploadModel
    {
        [FileSizeKB(1, 5 * 1024)]
        [FileAllowedExtensions(".jpg", ".jpeg", ".png")]
        [Required]
        public IFormFile image { get; set; }
    }
}
