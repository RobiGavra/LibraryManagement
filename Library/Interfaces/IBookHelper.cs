using LibraryManagement.Interfaces;

namespace Library.Interfaces
{
    public interface IBookHelper
    {
        public string GetBook(string name);

        public string GetBookById(int Id);

        public string GetBookByISBN(long ISBN);

        public string GetNumberOfBooks(string name);

        public string GetNumberOfBooks(long ISBN);

        public string GetDistinctBooks();

        public string AddBook(IBook book);

        public string RemoveBookById(int Id);

        public string RemoveBookByISBN(long ISBN);
    }
}
