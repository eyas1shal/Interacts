namespace Task5.Tabels
{
    public class Friendship
    {
        public int FriendshipId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string Status { get; set; }

        public User User { get; set; }
        public User Friend { get; set; }
    }
}

