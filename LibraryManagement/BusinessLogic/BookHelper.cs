using LibraryManagement.Interfaces;
using System.Linq;

namespace LibraryManagement.BusinessLogic
{
    public class BookHelper
    {
        private IBook[] books;

        public BookHelper(IBook[] books)
        {
            this.books = books;
        }

        public string GetBook(string name)
        {
            IBook book = this.books.ToList().Find(b => b.Name.ToLower().Contains(name.ToLower()));

            return ReturnMessage(book);
        }

        public string GetBookById(int Id)
        {
            IBook book = this.books.ToList().Find(b => b.Id == Id);

            return ReturnMessage(book);
        }

        public string GetBookByISBN(long ISBN)
        {
            IBook book = this.books.ToList().Find(b => b.ISBN == ISBN);

            return ReturnMessage(book);
        }

        public string AddBook(IBook book, long ISBN, string name, string author, double price)
        {
            book.Id = this.books.Length + 1;
            book.ISBN = ISBN;
            book.Name = name;
            book.Author = author;
            book.Price = price;
            book.Available = true;
            this.books.ToList().Add(book);

            return "Book added";
        }

        public string RemoveBookByID(int Id)
        {
            this.books.ToList().RemoveAll(x => x.Id == Id);

            return "Book removed";
        }

        public string RemoveBookByISBN(long ISBN)
        {
            this.books.ToList().RemoveAll(x => x.ISBN == ISBN);

            return "Book removed";
        }

        private string ReturnMessage(IBook? book)
        {
            if (book == null)
                return "Book doesn't exist";

            return $"User id: {book.Id}, ISBN: {book.ISBN}, full name: {book.Name}, author: {book.Author}, price: {book.Price}, available: {book.Available}";
        }
    }
}
