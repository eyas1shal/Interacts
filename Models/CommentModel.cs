namespace Task5.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
