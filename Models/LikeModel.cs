namespace Task5.Models
{
    public class LikeModel
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
