namespace Blogger.Models
{
    public class Comment
    {
        internal int id;
        internal string CommentId;

        public Comment(string name, int blogId)
        {
            Name = name;
            BlogId = BlogId;
        }

        public Comment()
        {

        }

        public string Name { get; set; }
        public int? BlogId { get; set; }
    }
}