namespace Blogger.Models
{
    public class Comment
    {
        internal int id;
        internal string CommentId;

        public Comment(string body, int blogId)
        {
            Body = body;
            BlogId = BlogId;
        }

        public Comment()
        {

        }

        public string Body { get; set; }

        public int? BlogId { get; set; }
    }
}