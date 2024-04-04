using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [Route("locationapi")]
    [ApiController]
    public class LocationController(ILocationService locationService) : Controller
    {
        private readonly ILocationService _locationService = locationService;

        [HttpGet("getallcity")]
        public async Task<IActionResult> GetAllCity()
        {
            var result = await _locationService.GetAllCityService();
            return Ok(result);
        }

        [HttpGet("getdistricts")]
        public async Task<IActionResult> GetAllDistrictByCityId(int cityId)
        {
            var result = await _locationService.GetAllDistrictByCityIdService(cityId);
            return Ok(result);
        }

        [HttpGet("getwards")]
        public async Task<IActionResult> GetAllWardByDistrictId(int districtId)
        {
            var result = await _locationService.GetAllWardByDistrictIdService(districtId);
            return Ok(result);
        }
    }
}
