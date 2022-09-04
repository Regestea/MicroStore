using AWS.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;

        public FileUploadController(IAWSFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }


        //[HttpPost("")]
        //public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        //{
        //    var response = await _fileRepository.UploadFile(Buckets.Names.category, Guid.NewGuid(), files);

        //    return Ok(response);
        //}
    }
}
