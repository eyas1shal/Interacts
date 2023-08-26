using Microsoft.Extensions.Hosting;

namespace Task5.Tabels
{
    public class User
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        public int NumPosts { get; set; }


        public  ICollection<Friendship> Friendships { get; set; }
        public  ICollection<Post> Posts { get; set; }
        public  ICollection<Like> Likes { get; set; }
        public  ICollection<Comment> Comments { get; set; }
    }
}
