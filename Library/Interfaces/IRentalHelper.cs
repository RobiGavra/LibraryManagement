using LibraryManagement.Interfaces;
using System;

namespace Library.Interfaces
{
    public interface IRentalHelper
    {
        public string RentBook(IRental rental);

        public string GetPrice(int bookId, int userId, DateTime currentDate);

        public string GetOverdueRentals(DateTime currentDate);

        public string ReturnBook(int bookId, int userId);
    }
}
