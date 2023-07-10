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
            DbMock data = new DbMock();
            UserHelper userHelper = new UserHelper(data.Users);
            BookHelper bookHelper = new BookHelper(data.Books);
            RentalHelper rentalHelper = new RentalHelper(data.Users, data.Books, data.Rentals);

            IUser newUser = new User() { FullName = "Marian Petrescu" };

            Console.WriteLine(userHelper.AddUser(newUser));
            Console.WriteLine(userHelper.GetUser("Marian Petrescu"));
        }
    }
}
