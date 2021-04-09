namespace Blogger.Models
{
    public class Blog
    {
        internal int id;
        internal string blogId;

        public Blog(string title, string body, int year)
        {
            Title = title;
            Body = body;

        }

        public Blog()
        {

        }

        public string Title { get; set; }
        public string Body { get; set; }
        public int Id { get; private set; }
    }
}