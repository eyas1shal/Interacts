using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task5.Models;
using Task5.Tabels;

namespace Task5.Services.Likes
{
    public class LikeServices : ILikeServices
    {
        private readonly ApplicationDbContext _context;

        public LikeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddLike(LikeModel likeServiceModel)
        {
            var like = new Like
            {
                UserId = likeServiceModel.UserId,
                PostId = likeServiceModel.PostId,
                Timestamp = DateTime.Now
                // Other properties
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveLike(int id)
        {
            var like = await _context.Likes.FindAsync(id);

            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> HasUserLikedPost(int userId, int postId)
        {
            return await _context.Likes
                .AnyAsync(l => l.UserId == userId && l.PostId == postId);
        }

        public async Task<int> GetLikesCountForPost(int postId)
        {
            return await _context.Likes
                .CountAsync(l => l.PostId == postId);
        }

        private LikeModel ConvertToLikeModel(Like like)
        {
            return new LikeModel
            {
                LikeId = like.LikeId,
                UserId = like.UserId,
                PostId = like.PostId,
                Timestamp = like.Timestamp
                // Other properties
            };
        }
    }
}
