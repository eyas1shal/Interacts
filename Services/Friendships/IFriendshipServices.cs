using Task5.Models;

namespace Task5.Services.Friendships
{
    public interface IFriendshipServices
    {
        Task<ICollection<UserModel>> GetFriendsAsync(int userId);

        Task<IEnumerable<UserModel>> GetFriendRequestsAsync(int currentUserId);
        Task SendRequestAsync(int currentUserId, int addresseeId);

        Task AcceptRequestAsync(int currentUserId, int requesterId);

        Task RejectRequestAsync(int currentUserId, int requesterId);

        Task CancelInvitationAsync(int currentUserId, int addresseeId);

        Task UnfriendAsync(int currentUserId, int  friendId);
    }
}
