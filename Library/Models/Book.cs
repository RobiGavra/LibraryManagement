using LibraryManagement.Interfaces;

namespace LibraryManagement.Models
{
    public class Book : IBook
    {
        public int Id { get; set; }

        public long ISBN { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public double Price { get; set; }

        public bool Available { get; set; }

        public bool Removed { get; set; }
    }
}
