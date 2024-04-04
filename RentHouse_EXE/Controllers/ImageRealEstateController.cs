using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [ApiController]
    [Route("ImageRealEstateApi")]
    public class ImageRealEstateController : Controller
    {
        private readonly IImageRealEstateService _imageRealEstateService;

        public ImageRealEstateController(IImageRealEstateService imageRealEstateService)
        {
            _imageRealEstateService = imageRealEstateService;
        }

        [HttpPost("UploadImageRealEstate/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UploadImageRealEstate([FromForm(Name = "Data")] List<IFormFile> files, [FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (files.Count == 0)
                {
                    return BadRequest("No file uploaded");
                }                
                if (await _imageRealEstateService.UploadImageRealEstateAsync(files, id))
                {
                    return Ok("Upload Successfully!");
                }
                else
                {
                    throw new Exception("Upload image fail");
                }                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
