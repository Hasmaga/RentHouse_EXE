using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [Route("FurnitureApi")]
    [ApiController]
    public class FurnitureController : Controller
    {
        private readonly IFurnitureService _furnitureService;

        public FurnitureController(IFurnitureService furnitureService)
        {
            _furnitureService = furnitureService;
        }

        [HttpPost("createfurniture")]
        public async Task<IActionResult> CreateFurniture(CreateFurnitureReqDto createFurnitureReqDto)
        {
            try
            {
                return Ok(await _furnitureService.CreateFurnitureAsync(createFurnitureReqDto));
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("getallfurniture")]
        public async Task<IActionResult> GetAllListFurniture()
        {
            try
            {
                return Ok(await _furnitureService.GetAllListFurnitureAsync());
            } catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
