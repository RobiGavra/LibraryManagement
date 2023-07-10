using LibraryManagement.Interfaces;

namespace LibraryManagement.Models
{
    public class User : IUser
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
