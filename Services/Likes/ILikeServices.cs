using System.Threading.Tasks;
using Task5.Models;

namespace Task5.Services.Likes
{
    public interface ILikeServices
    {
        Task AddLike(LikeModel likeServiceModel);

        Task RemoveLike(int id);

        Task<bool> HasUserLikedPost(int userId, int postId);

        Task<int> GetLikesCountForPost(int postId);
    }
}
