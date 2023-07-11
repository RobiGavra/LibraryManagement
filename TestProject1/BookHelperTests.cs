using Library.Interfaces;
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
        public void GetUser_GetbyName_GetbyId_GetbyISBN_SuccessAndFailureFlow_ReturnsCorrespondentMessages()
        {
            IBookHelper bookHelper = new BookHelper(DataMock.MockBooks());

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
        public void GetNumberOfBooks_GetbyName_GetbyISBN_ReturnsBooksNumber()
        {
            IBookHelper bookHelper = new BookHelper(DataMock.MockBooks());

            string booksByName = bookHelper.GetNumberOfBooks("Ursul pacalit de vulpe");

            Assert.AreEqual(booksByName, "We have 2 copies of which 1 are available");

            string bookByISBN = bookHelper.GetNumberOfBooks(0923644768);

            Assert.AreEqual(bookByISBN, "We have 1 copies of which 0 are available");
        }

        [TestMethod]
        public void GetDistinctBooks_ReturnsListOfDistinctBooks()
        {
            IBookHelper bookHelper = new BookHelper(DataMock.MockBooks());

            string books = bookHelper.GetDistinctBooks();
            string expected = "Books:" + System.Environment.NewLine + "Ursul pacalit de vulpe" + System.Environment.NewLine + "Ion" + System.Environment.NewLine;

            Assert.AreEqual(books, expected);
        }

        [TestMethod]
        public void AddBook_CreateNewBook_CheckIfBookCreated_ReturnsSuccessMessage()
        {
            IBookHelper bookHelper = new BookHelper(DataMock.MockBooks());

            IBook book = new Book()
            {
                ISBN = 923645769,
                Name = "Cel mai iubit dintre pământeni",
                Author = "Marin Preda",
                Price = 20.5
            };

            string message = bookHelper.AddBook(book);

            Assert.AreEqual(message, "Book added");

            string bookByISBN = bookHelper.GetBookByISBN(923645769);

            Assert.AreEqual(bookByISBN, "Book id: 4, ISBN: 923645769, full name: Cel mai iubit dintre pământeni, author: Marin Preda, price: 20.5, available: True");
        }

        [TestMethod]
        public void RemoveBook_SoftDelete_CheckIfBookDeleted_ReturnsSuccessMessage()
        {
            IBookHelper bookHelper = new BookHelper(DataMock.MockBooks());

            string message = bookHelper.RemoveBookById(1);

            Assert.AreEqual(message, "Book removed");

            string bookById = bookHelper.GetBookById(1);

            Assert.AreEqual(bookById, "Book doesn't exist");
        }
    }
}
