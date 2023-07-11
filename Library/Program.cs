using Library.Interfaces;
using LibraryManagement;
using LibraryManagement.BusinessLogic;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbMock data = new DbMock();
            IUserHelper userHelper = new UserHelper(data.Users);
            IBookHelper bookHelper = new BookHelper(data.Books);
            IRentalHelper rentalHelper = new RentalHelper(data.Users, data.Books, data.Rentals);

            IUser newUser = new User() { FullName = "Marian Petrescu" };

            Console.WriteLine(userHelper.AddUser(newUser));
            Console.WriteLine(userHelper.GetUser("Marian Petrescu"));
            Console.WriteLine(bookHelper.GetDistinctBooks());
            Console.WriteLine(rentalHelper.GetOverdueRentals(new DateTime(2023, 10, 20)));
        }
    }
}
