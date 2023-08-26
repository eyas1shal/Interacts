using Task5.Models;

namespace Task5.Services.Posts
{
    public interface IPostServices
    {
        Task AddPost(PostModel serviceModel);

        Task EditPost(PostModel serviceModel);

        Task DeletePost(int id);

        Task<PostModel> GetPost(int id);

        Task<ICollection<PostModel>> GetPostsByUserIdAsync(int userId);
    }
}
