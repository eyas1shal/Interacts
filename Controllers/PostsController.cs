using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task5.Models;
using Task5.Services.Posts;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostServices _postService;

        public PostsController(IPostServices postService)
        {
            _postService = postService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddPost(PostModel model)
        {
            await _postService.AddPost(model);
            return Ok("Post added successfully.");
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditPost(PostModel model)
        {
            await _postService.EditPost(model);
            return Ok("Post edited successfully.");
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return Ok("Post deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            return Ok(post);
        }

        [HttpGet("ByUser/{userId}")]
        public async Task<IActionResult> GetPostsByUserIdAsync(int userId)
        {
            var posts = await _postService.GetPostsByUserIdAsync(userId);
            return Ok(posts);
        }
    }
}
