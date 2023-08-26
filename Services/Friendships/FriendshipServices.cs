using Microsoft.EntityFrameworkCore;
using Task5.Models;
using Task5.Tabels;

namespace Task5.Services.Friendships
{
    public class FriendshipServices : IFriendshipServices
    {
        private readonly ApplicationDbContext _context;

        public FriendshipServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<UserModel>> GetFriendsAsync(int userId)
        {
            var friends = await _context.Friendships
                .Where(f => (f.UserId == userId || f.FriendId == userId) && f.Status == "Accepted")
                .Select(f => f.UserId == userId ? f.Friend : f.User)
                .ToListAsync();

            var friendModels = friends.Select(ConvertToUserModel).ToList();
            return friendModels;
        }

        public async Task<IEnumerable<UserModel>> GetFriendRequestsAsync(int currentUserId)
        {
            var friendRequests = await _context.Friendships
                .Where(f => f.FriendId == currentUserId && f.Status == "Pending")
                .Select(f => f.User)
                .ToListAsync();

            var friendRequestModels = friendRequests.Select(ConvertToUserModel).ToList();
            return friendRequestModels;
        }

        public async Task SendRequestAsync(int currentUserId, int addresseeId)
        {
            var existingRequest = await _context.Friendships
                .FirstOrDefaultAsync(f => (f.UserId == currentUserId && f.FriendId == addresseeId) ||
                                          (f.UserId == addresseeId && f.FriendId == currentUserId));

            if (existingRequest == null)
            {
                var friendship = new Friendship
                {
                    UserId = currentUserId,
                    FriendId = addresseeId,
                    Status = "Pending"
                };

                _context.Friendships.Add(friendship);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AcceptRequestAsync(int currentUserId, int requesterId)
        {
            var request = await GetFriendshipRequest(currentUserId, requesterId);

            if (request != null)
            {
                request.Status = "Accepted";
                await _context.SaveChangesAsync();
            }
        }

        public async Task RejectRequestAsync(int currentUserId, int requesterId)
        {
            var request = await GetFriendshipRequest(currentUserId, requesterId);

            if (request != null)
            {
                _context.Friendships.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CancelInvitationAsync(int currentUserId, int addresseeId)
        {
            var invitation = await GetFriendshipRequest(currentUserId, addresseeId);

            if (invitation != null)
            {
                _context.Friendships.Remove(invitation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UnfriendAsync(int currentUserId, int friendId)
        {
            var friendship = await _context.Friendships
                .FirstOrDefaultAsync(f =>
                    (f.UserId == currentUserId && f.FriendId == friendId) ||
                    (f.UserId == friendId && f.FriendId == currentUserId));

            if (friendship != null)
            {
                _context.Friendships.Remove(friendship);
                await _context.SaveChangesAsync();
            }
        }

        private UserModel ConvertToUserModel(User user)
        {
            return new UserModel
            {
                UserId = user.UserId,
                FullName = user.FullName,
                // Other properties
            };
        }

        private async Task<Friendship> GetFriendshipRequest(int currentUserId, int requesterId)
        {
            return await _context.Friendships
                .FirstOrDefaultAsync(f => f.UserId == requesterId && f.FriendId == currentUserId && f.Status == "Pending");
        }
    }
}



/*using Task5.Models;

namespace Task5.Services.Friendships
{
    public class FriendshipServices : IFriendshipServices
    {
        private readonly ApplicationDbContext _data;

        public FriendshipServices(ApplicationDbContext data) => this._data = data;
        
        public async Task<ICollection<UserModel>> GetFriendsAsync(string userId)
        {
            //Get current user friendships where it is addressee or requester
            var friendships = await GetFriendshipsByUserIdAsync(userId);

            var addressee = friendships
                .Select(a => a.Addressee)
                .ToList();

            var requesters = friendships
                .Select(r => r.Requester)
                .ToList();

            var friends = addressee
                .Concat(requesters)
                .ToList();

            friends.RemoveAll(u => u.Id == userId);

            return (ICollection<UserModel>)friends;
        }
        


        public Task AcceptRequestAsync(string currentUserId, string requesterId)
        {
            throw new NotImplementedException();
        }

        public Task CancelInvitationAsync(string currentUserId, string addresseeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetFriendRequestsAsync(string currentUserId)
        {
            throw new NotImplementedException();
        }


        public Task RejectRequestAsync(string currentUserId, string requesterId)
        {
            throw new NotImplementedException();
        }

        public Task SendRequestAsync(string currentUserId, string addresseeId)
        {
            throw new NotImplementedException();
        }

        public Task UnfriendAsync(string currentUserId, string friendId)
        {
            throw new NotImplementedException();
        }
    }
}
/*/