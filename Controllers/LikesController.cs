using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Task5.Models;
using Task5.Services.Likes;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeServices _likeServices;

        public LikesController(ILikeServices likeServices)
        {
            _likeServices = likeServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(LikeModel likeModel)
        {
            try
            {
                await _likeServices.AddLike(likeModel);
                return Ok("Like added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLike(int id)
        {
            try
            {
                await _likeServices.RemoveLike(id);
                return Ok("Like removed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("HasUserLikedPost")]
        public async Task<IActionResult> HasUserLikedPost(int userId, int postId)
        {
            try
            {
                var hasLiked = await _likeServices.HasUserLikedPost(userId, postId);
                return Ok(hasLiked);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetLikesCountForPost")]
        public async Task<IActionResult> GetLikesCountForPost(int postId)
        {
            try
            {
                var likesCount = await _likeServices.GetLikesCountForPost(postId);
                return Ok(likesCount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
