using Task5.Models;

namespace Task5.Services.Comments
{
    public interface ICommentServices
    {
        Task AddComment(CommentModel commentServiceModel);

        Task EditComment(CommentModel serviceModel);

        Task DeleteComment(int id);

        Task<CommentModel> GetComment(int id);

        Task<ICollection<CommentModel>> GetCommentsByPostIdAsync(int postId);
    }
}
