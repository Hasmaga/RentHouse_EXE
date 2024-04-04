using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Model;
using RentHouse_EXE.Model.ReqDto.Plan;
using RentHouse_EXE.Service.Interface;
using System.Diagnostics.Metrics;

namespace RentHouse_EXE.Controllers
{
    [Route("PlanAPI")]
    [ApiController]
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;


        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        [Route("CreatePlan")]
        public async Task<IActionResult> CreatePlanAsync([FromBody] CreatePlanResDto plan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }                
                return Ok(await _planService.CreatePlanAsync(plan));
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
            
        }

        [HttpGet]
        [Route("GetListPlan")]
        public async Task<IActionResult> GetListPlanAsync()
        {
            try
            {
                return Ok(await _planService.GetListPlanAsync());
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }                      
        }

        [HttpPost]
        [Route("CreatePlanDate")]
        public async Task<IActionResult> CreatePlanDateAsync([FromBody] CreatePlanDayReqDto planDay)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }                    
                return Ok(await _planService.CreatePlanDayAsync(planDay));
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }            
        }

        [HttpPost]
        [Route("CreatePlanPrice")]
        public async Task<IActionResult> CreatePlanPriceAsync([FromBody] CreatePlanPriceReqDto planPrice)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _planService.CreatePlanPriceAsync(planPrice));                    
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpPost]
        [Route("CreatePriceDecreases")]
        public async Task<IActionResult> CreatePriceDecreasesAsync([FromBody] CreatePriceDescreaseReqDto priceDecreases)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _planService.CreatePriceDecreasesAsync(priceDecreases));
            }
            catch (Exception)
            {   
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetListPlanDay")]
        public async Task<IActionResult> GetListPlanDayAsync()
        {
            try
            {
                return Ok(await _planService.GetListPlanDayAsync());
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetListPlanPrice")]
        public async Task<IActionResult> GetListPlanPriceAsync()
        {
            try
            {
                return Ok(await _planService.GetListPlanPriceAsync());
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetListPriceDecreases")]
        public async Task<IActionResult> GetListPriceDecreasesAsync() 
        {
            try
            {
                return Ok(await _planService.GetListPriceDecreasesAsync());
            } catch(Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetListPlanPriceResDto")]
        public async Task<IActionResult> GetListPlanPriceResDtoAsync()
        {
            try
            {
                return Ok(await _planService.GetListPlanPriceResDtoAsync());
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetPlanPriceOfDayByPlanId")]
        public async Task<IActionResult> GetPlanPriceOfDayByPlanIdAsync(Guid planId)
        {
            try
            {
                return Ok(await _planService.GetListPlanPriceOfDayAysnc(planId));
            } catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

    }
}
