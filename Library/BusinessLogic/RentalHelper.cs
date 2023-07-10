using LibraryManagement.Interfaces;
using System;
using System.Collections.Generic;
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

        public string RentBook(IRental rental)
        {
            IBook book = books.FirstOrDefault(b => b.Id == rental.Book.Id && b.Available);
            IUser user = users.Single(u => u.Id == rental.User.Id);

            if (book == null)
                return "not available";

            List<IRental> rentals = this.rentals.ToList();
            rental.Id = this.rentals.Count() + 1;
            rental.User = user;
            book.Available = false;
            rental.Book = book;
            rentals.Add(rental);

            this.rentals = rentals.ToArray();

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

        public string ReturnBook(int bookId, int userId)
        {
            IBook book = this.books.SingleOrDefault(b => b.Id == bookId);

            if (book == null)
                return "book not found in system";

            IRental rental = this.rentals.SingleOrDefault(r => r.Book.Id == bookId && r.User.Id == userId && !r.BookReturned);

            if (rental == null)
                return "rental not found in system";

            book.Available = true;
            rental.BookReturned = true;

            return "Book Returned";
        }
    }
}