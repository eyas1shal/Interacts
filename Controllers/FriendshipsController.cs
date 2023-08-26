using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task5.Models;
using Task5.Services.Friendships;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipsController : ControllerBase
    {
        private readonly IFriendshipServices _friendshipService;

        public FriendshipsController(IFriendshipServices friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet("Friends/{userId}")]
        public async Task<IActionResult> GetFriendsAsync(int userId)
        {
            var friends = await _friendshipService.GetFriendsAsync(userId);
            return Ok(friends);
        }

        [HttpGet("FriendRequests/{currentUserId}")]
        public async Task<IActionResult> GetFriendRequestsAsync(int currentUserId)
        {
            var friendRequests = await _friendshipService.GetFriendRequestsAsync(currentUserId);
            return Ok(friendRequests);
        }

        [HttpPost("SendRequest")]
        public async Task<IActionResult> SendRequestAsync(FriendshipModel model)
        {
            await _friendshipService.SendRequestAsync(model.UserId, model.FriendId);
            return Ok("Friend request sent.");
        }

        [HttpPost("AcceptRequest")]
        public async Task<IActionResult> AcceptRequestAsync(FriendshipModel model)
        {
            await _friendshipService.AcceptRequestAsync(model.UserId, model.FriendId);
            return Ok("Friend request accepted.");
        }

        [HttpPost("RejectRequest")]
        public async Task<IActionResult> RejectRequestAsync(FriendshipModel model)
        {
            await _friendshipService.RejectRequestAsync(model.UserId, model.FriendId);
            return Ok("Friend request rejected.");
        }

        [HttpPost("CancelInvitation")]
        public async Task<IActionResult> CancelInvitationAsync(FriendshipModel model)
        {
            await _friendshipService.CancelInvitationAsync(model.UserId, model.FriendId);
            return Ok("Friend invitation canceled.");
        }

        [HttpPost("Unfriend")]
        public async Task<IActionResult> UnfriendAsync(FriendshipModel model)
        {
            await _friendshipService.UnfriendAsync(model.UserId, model.FriendId);
            return Ok("Unfriended successfully.");
        }
    }
}
