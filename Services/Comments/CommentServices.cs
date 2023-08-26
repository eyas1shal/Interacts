using Microsoft.EntityFrameworkCore;
using Task5.Models;
using Task5.Tabels;

namespace Task5.Services.Comments
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext _context;

        public CommentServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddComment(CommentModel commentServiceModel)
        {
            var comment = new Comment
            {
                UserId = commentServiceModel.UserId,
                PostId = commentServiceModel.PostId,
                Content = commentServiceModel.Content
                // Other properties
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task EditComment(CommentModel serviceModel)
        {
            var comment = await _context.Comments.FindAsync(serviceModel.CommentId);

            if (comment != null)
            {
                comment.Content = serviceModel.Content;
                // Update other properties if needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CommentModel> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            return ConvertToCommentModel(comment);
        }

        public async Task<ICollection<CommentModel>> GetCommentsByPostIdAsync(int postId)
        {
            var comments = await _context.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();

            var commentModels = comments.Select(ConvertToCommentModel).ToList();
            return commentModels;
        }

        private CommentModel ConvertToCommentModel(Comment comment)
        {
            return new CommentModel
            {
                CommentId = comment.CommentId,
                UserId = comment.UserId,
                PostId = comment.PostId,
                Content = comment.Content
            };
        }
    }
}
