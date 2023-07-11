using LibraryManagement.Interfaces;

namespace Library.Interfaces
{
    public interface IDbMock
    {
        public IUser[] Users { get; set; }

        public IBook[] Books { get; set; }

        public IRental[] Rentals { get; set; }
    }
}
