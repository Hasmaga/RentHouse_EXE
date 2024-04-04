using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [ApiController]
    [Route("TypeRealEstateApi")]
    public class TypeRealEstateController : Controller
    {
        private readonly ITypeRealEstateService _typeRealEstateService;

        public TypeRealEstateController(ITypeRealEstateService typeRealEstateService)
        {
            _typeRealEstateService = typeRealEstateService;
        }

        [HttpPost("CreateTypeRealEstate")]
        [Authorize]
        public async Task<IActionResult> CreateTypeRealEstate([FromBody] CreateTypeRealEstateResDto typeRealEstate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _typeRealEstateService.CreateTypeRealEstateAsync(typeRealEstate);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetListTypeRealEstate")]
        public async Task<IActionResult> GetListTypeRealEstate()
        {
            try
            {
                var result = await _typeRealEstateService.GetListTypeRealEstateAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
