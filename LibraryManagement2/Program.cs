using LibraryManagement;
using LibraryManagement.BusinessLogic;
using LibraryManagement.Models;
using System;

namespace LibraryManagement2
{
    class Program
    {
        static void Main(string[] args)
        {
            DbMock data = new DbMock();
            UserHelper userHelper = new UserHelper(data.Users);
            BookHelper bookHelper = new BookHelper(data.Books);
            RentalHelper rentalHelper = new RentalHelper(data.Users, data.Books, data.Rentals);

            Console.WriteLine(rentalHelper.RentBook(new Rental(), 3, 1, new DateTime(2023, 08, 20)));
        }
    }
}
