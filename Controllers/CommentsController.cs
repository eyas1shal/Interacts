using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task5.Models;
using Task5.Services.Comments;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentServices _commentService;

        public CommentsController(ICommentServices commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddComment(CommentModel model)
        {
            await _commentService.AddComment(model);
            return Ok("Comment added successfully.");
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditComment(CommentModel model)
        {
            await _commentService.EditComment(model);
            return Ok("Comment edited successfully.");
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);
            return Ok("Comment deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetComment(id);
            return Ok(comment);
        }

        [HttpGet("ByPost/{postId}")]
        public async Task<IActionResult> GetCommentsByPostIdAsync(int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }
    }
}
