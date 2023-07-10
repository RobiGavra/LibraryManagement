using LibraryManagement.Interfaces;
using System;
using System.Linq;

namespace LibraryManagement.BusinessLogic
{
    public class RentalHelper
    {
        private IUser[] users;
        private IBook[] books;
        private IRental[] rentals;

        public RentalHelper(IUser[] users, IBook[] books, IRental[] rentals)
        {
            this.users = users;
            this.books = books;
            this.rentals = rentals;
        }

        public string RentBook(IRental rental, int bookId, int userId, DateTime currentDate)
        {
            IBook book = books.FirstOrDefault(b => b.Id == bookId && b.Available);
            IUser user = users.Single(u => u.Id == userId);

            if (book == null)
                return "not available";

            book.Available = false;
            rental.Id = rentals.Count() + 1;
            rental.User = user;
            rental.Book = book;
            rental.RentalDate = currentDate;

            return "order registered";
        }

        public string GetPrice(int bookId, int userId, DateTime currentDate)
        {
            IBook book = books.SingleOrDefault(b => b.Id == bookId);

            if (book == null)
                return "book not found in system";

            IRental rental = rentals.SingleOrDefault(r => r.Book.Id == bookId && r.User.Id == userId && !r.BookReturned);

            if (rental == null)
                return "rental not found in system";

            return $"You need to pay {rental.GetFullPrice(currentDate)}, of which the penalties are {rental.GetPenalty(currentDate)}";
        }

        public string ReturnBook(int bookId, int userId, DateTime currentDate)
        {
            IBook book = books.SingleOrDefault(b => b.Id == bookId);

            if (book == null)
                return "book not found in system";

            IRental rental = rentals.SingleOrDefault(r => r.Book.Id == bookId && r.User.Id == userId && !r.BookReturned);

            if (rental == null)
                return "rental not found in system";

            book.Available = true;
            rental.BookReturned = true;

            return $"Book Returned";
        }
    }
}