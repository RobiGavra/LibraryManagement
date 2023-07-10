using LibraryManagement.BusinessLogic;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LibraryTest
{
    [TestClass]
    public class RentalHelperTests
    {
        [TestMethod]
        public void Rent()
        {
            RentalHelper rentalHelper = new RentalHelper(DataGenerator.MockUsers(), DataGenerator.MockBooks(), DataGenerator.MockRentals());

            IRental rental = new Rental()
            {
                User = new User() { Id = 3 },
                Book = new Book() { Id = 1 },
                RentalDate = new DateTime(2023, 06, 20)
            };

            string message = rentalHelper.RentBook(rental);

            Assert.AreEqual(message, "not available");

            rental.Book.Id = 3;

            message = rentalHelper.RentBook(rental);

            Assert.AreEqual(message, "order registered");
        }

        [TestMethod]
        public void GetPrice()
        {
            RentalHelper rentalHelper = new RentalHelper(DataGenerator.MockUsers(), DataGenerator.MockBooks(), DataGenerator.MockRentals());
            DateTime returnDate = new DateTime(2023, 03, 01).AddDays(14);
            DateTime currentDate = new DateTime(2023, 03, 20);

            string message = rentalHelper.GetPrice(5, 2, currentDate);

            Assert.AreEqual(message, "book not found in system");

            message = rentalHelper.GetPrice(1, 2, currentDate);

            Assert.AreEqual(message, "rental not found in system");

            int diffOfDates = currentDate.Subtract(returnDate).Days;
            double price = 15.0;
            double penalty = 0.01 * price * diffOfDates;
            double fullPrice = penalty + price;

            message = rentalHelper.GetPrice(2, 2, currentDate);

            Assert.AreEqual(message, $"You need to pay {fullPrice}, of which the penalties are {penalty}");
        }

        [TestMethod]
        public void GetOverduerentals()
        {
            RentalHelper rentalHelper = new RentalHelper(DataGenerator.MockUsers(), DataGenerator.MockBooks(), DataGenerator.MockRentals());

            string books = rentalHelper.GetOverduerentals(new DateTime(2023, 10, 20));
            string expected = "Overduerentals:" + System.Environment.NewLine + "Ursul pacalit de vulpe" + System.Environment.NewLine + "Ion" + System.Environment.NewLine;

            Assert.AreEqual(books, expected);
        }

        [TestMethod]
        public void ReturnBook()
        {
            IBook[] books = DataGenerator.MockBooks();
            IRental[] rentals = DataGenerator.MockRentals();

            RentalHelper rentalHelper = new RentalHelper(DataGenerator.MockUsers(), books, rentals);

            bool bookAvailable = books.First(b => b.Id == 2).Available;
            bool rentalBookReturned = rentals.First(r => r.Book.Id == 2 && r.User.Id == 2).BookReturned;

            Assert.IsFalse(bookAvailable);
            Assert.IsFalse(rentalBookReturned);

            string message = rentalHelper.ReturnBook(2, 2);

            Assert.AreEqual(message, "Book Returned");

            bookAvailable = books.First(b => b.Id == 2).Available;
            rentalBookReturned = rentals.First(r => r.Book.Id == 2 && r.User.Id == 2).BookReturned;

            Assert.IsTrue(bookAvailable);
            Assert.IsTrue(rentalBookReturned);
        }
    }
}
