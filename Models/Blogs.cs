namespace Blogger.Models
{
    public class Blog
    {
        internal int id;
        internal string blogId;

        public Blog(string make, string model, int year)
        {
            // Make = make;
            // Model = model;
            // Year = year;
        }

        public Blog()
        {

        }

        // public string Make { get; set; }
        // public string Model { get; set; }
        // public int? Year { get; set; }
        // public int Id { get; private set; }
    }
}