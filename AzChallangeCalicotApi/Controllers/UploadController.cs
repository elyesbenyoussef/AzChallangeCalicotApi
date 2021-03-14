using AzChallangeCalicotApi.Type.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IBlobStorageService _blobStorageService;

        public UploadController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadProfilePicture()
        {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            var result = await _blobStorageService.UploadFileBlobAsync(
                    file.OpenReadStream(),
                    file.ContentType,
                    file.FileName);

            var toReturn = result.AbsoluteUri;

            return Ok(new { path = toReturn });
        }
    }
}
