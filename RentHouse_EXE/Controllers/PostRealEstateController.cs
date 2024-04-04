using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [ApiController]
    [Route("PostRealEstateApi")]
    public class PostRealEstateController : Controller
    {
        private readonly IPostService _postService;

        public PostRealEstateController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreatePost")]
        [Authorize]
        public async Task<IActionResult> CreatePost(CreatePostRealEstateReqDto postRealEstateReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _postService.CreatePostRealEstateAsync(postRealEstateReqDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTitleRentPostRealEstate")]
        public async Task<IActionResult> GetTitleRentPostRealEstate()
        {
            try
            {
                var result = await _postService.GetTitleRentPostRealEstateAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTitleBuyPostRealEstate")]
        public async Task<IActionResult> GetTitleBuyPostRealEstate()
        {
            try
            {
                var result = await _postService.GetTitleBuyPostRealEstateAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetPostRealEstateById/{id}")]
        public async Task<IActionResult> GetPostRealEstateById([FromRoute]Guid id)
        {
            try
            {
                var result = await _postService.GetPostRealEstateByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetPostRealEstateByCutomerId")]
        [Authorize]
        public async Task<IActionResult> GetPostRealEstateByCustomerId()
        {
            try
            {
                var result = await _postService.GetTitlePostRealEstateByCustomerIdAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetCustomerPostRealEstateById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCustomerPostRealEstateById([FromRoute]Guid id)
        {
            try
            {
                var result = await _postService.GetCustomerPostRealEstateByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTitleRentPostRealEstateByPlanTop")]
        public async Task<IActionResult> GetTitleRentPostRealEstateByPlanTop()
        {
            try
            {
                var result = await _postService.GetTitleRentPostRealEstateByPlanTopAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTitleBuyPostRealEstateByPlanTop")]

        public async Task<IActionResult> GetTitleBuyPostRealEstateByPlanTop()
        {
            try
            {
                var result = await _postService.GetTitleBuyPostRealEstateByPlanTopAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
