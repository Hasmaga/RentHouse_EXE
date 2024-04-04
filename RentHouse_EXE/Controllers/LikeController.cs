using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse_EXE.Service.Interface;

namespace RentHouse_EXE.Controllers
{
    [ApiController]
    [Route("LikeApi")]
    public class LikeController : Controller
    {
        private readonly ILikeCommentService _likeCommentService;

        public LikeController(ILikeCommentService likeCommentService)
        {
            _likeCommentService = likeCommentService;
        }

        [HttpPost("LikeComment/{commentId}")]
        [Authorize]
        public async Task<IActionResult> LikeCommentAsync([FromRoute] Guid commentId)
        {
            try
            {
                var result = await _likeCommentService.LikeCommentAsync(commentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("UnlikeComment")]
        [Authorize]
        public async Task<IActionResult> UnlikeCommentAsync(Guid likeCommentId)
        {
            try
            {
                var result = await _likeCommentService.UnlikeCommennAsync(likeCommentId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
