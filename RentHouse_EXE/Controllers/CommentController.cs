using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Model.ReqDto;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [ApiController]
    [Route("CommentApi")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("CreateComment")]
        [Authorize]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentReqDto comment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(await _commentService.CreateCommentAsync(comment));
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpGet("GetListCommentByPostId/{postId}")]
        public async Task<IActionResult> GetListCommentAsync([FromRoute] Guid postId)
        {
            try
            {
                return Ok(await _commentService.GetListCommentByPostIdAsync(postId));
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }   
    }
}
