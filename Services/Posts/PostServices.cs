using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task5.Models;
using Task5.Tabels;

namespace Task5.Services.Posts
{
    public class PostServices : IPostServices
    {
        private readonly ApplicationDbContext _context;

        public PostServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(PostModel serviceModel)
        {
            var post = new Post
            {
                UserId = serviceModel.UserId,
                Content = serviceModel.Content
                // Other properties
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task EditPost(PostModel serviceModel)
        {
            var post = await _context.Posts.FindAsync(serviceModel.PostId);

            if (post != null)
            {
                post.Content = serviceModel.Content;
                // Update other properties if needed
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PostModel> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return ConvertToPostModel(post);
        }

        public async Task<ICollection<PostModel>> GetPostsByUserIdAsync(int userId)
        {
            var posts = await _context.Posts
                .Where(p => p.UserId == userId)
                .ToListAsync();

            var postModels = posts.Select(ConvertToPostModel).ToList();
            return postModels;
        }

        private PostModel ConvertToPostModel(Post post)
        {
            return new PostModel
            {
                PostId = post.PostId,
                UserId = post.UserId,
                Content = post.Content
                // Other properties
            };
        }
    }
}
