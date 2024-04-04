using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [Route("PriceUnit")]
    [ApiController]
    public class PlanUnitController : Controller
    {
        private readonly IPriceUnitService _priceUnitService;

        public PlanUnitController(IPriceUnitService priceUnitService)
        {
            _priceUnitService = priceUnitService;
        }

        [HttpPost]
        [Route("CreatePriceUnit")]
        public async Task<IActionResult> CreatePriceUnitAsync([FromBody] CreatePriceUnitReqDto priceUnit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _priceUnitService.CreatePriceUnitAsync(priceUnit));
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetListPriceUnit")]
        public async Task<IActionResult> GetListPriceUnitAsync()
        {
            try
            {
                return Ok(await _priceUnitService.GetAllPriceUnitsAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }
    }
}
