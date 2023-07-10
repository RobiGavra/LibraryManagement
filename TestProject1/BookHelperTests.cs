using LibraryManagement.BusinessLogic;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class BookHelperTests
    {
        [TestMethod]
        public void GetUser()
        {
            BookHelper bookHelper = new BookHelper(DataGenerator.MockBooks());

            string bookByName = bookHelper.GetBook("Ionica");

            Assert.AreEqual(bookByName, "Book doesn't exist");

            bookByName = bookHelper.GetBook("Ion");

            Assert.AreEqual(bookByName, "Book id: 2, ISBN: 923644768, full name: Ion, author: Liviu Rebreanu, price: 15, available: False");

            string bookById = bookHelper.GetBookById(8);

            Assert.AreEqual(bookById, "Book doesn't exist");

            bookById = bookHelper.GetBookById(2);

            Assert.AreEqual(bookById, "Book id: 2, ISBN: 923644768, full name: Ion, author: Liviu Rebreanu, price: 15, available: False");

            string bookByISBN = bookHelper.GetBookByISBN(8);

            Assert.AreEqual(bookByISBN, "Book doesn't exist");

            bookByISBN = bookHelper.GetBookByISBN(923644768);

            Assert.AreEqual(bookByISBN, "Book id: 2, ISBN: 923644768, full name: Ion, author: Liviu Rebreanu, price: 15, available: False");
        }

        [TestMethod]
        public void AddBook()
        {
            BookHelper bookHelper = new BookHelper(DataGenerator.MockBooks());

            IBook book = new Book()
            {
                ISBN = 923645769,
                Name = "Cel mai iubit dintre pământeni",
                Author = "Marin Preda",
                Price = 20.5
            };

            bookHelper.AddBook(book);

            string bookByISBN = bookHelper.GetBookByISBN(923645769);

            Assert.AreEqual(bookByISBN, "Book id: 4, ISBN: 923645769, full name: Cel mai iubit dintre pământeni, author: Marin Preda, price: 20.5, available: True");
        }

        [TestMethod]
        public void RemoveBook()
        {
            BookHelper bookHelper = new BookHelper(DataGenerator.MockBooks());

            bookHelper.RemoveBookById(1);

            string bookById = bookHelper.GetBookById(1);

            Assert.AreEqual(bookById, "Book doesn't exist");

            bookHelper.RemoveBookByISBN(923644768);

            string bookByISBN = bookHelper.GetBookByISBN(923644768);

            Assert.AreEqual(bookByISBN, "Book doesn't exist");
        }
    }
}
