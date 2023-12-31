﻿using Library.Interfaces;
using LibraryManagement.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.BusinessLogic
{
    public class BookHelper : IBookHelper
    {
        private IBook[] books;

        public BookHelper(IBook[] books)
        {
            this.books = books;
        }

        public string GetBook(string name)
        {
            IBook book = this.books.FirstOrDefault(b => b.Name.ToLower().Contains(name.ToLower()) && !b.Removed);

            return ReturnMessage(book);
        }

        public string GetBookById(int Id)
        {
            IBook book = this.books.SingleOrDefault(b => b.Id == Id && !b.Removed);

            return ReturnMessage(book);
        }

        public string GetBookByISBN(long ISBN)
        {
            IBook book = this.books.FirstOrDefault(b => b.ISBN == ISBN && !b.Removed);

            return ReturnMessage(book);
        }

        public string GetNumberOfBooks(string name)
        {
            int allBooks = this.books.Where(b => b.Name.ToLower() == name.ToLower()).Count();
            int availableBooks = this.books.Where(b => b.Name.ToLower() == name.ToLower() && b.Available).Count();

            return $"We have {allBooks} copies of which {availableBooks} are available";
        }

        public string GetNumberOfBooks(long ISBN)
        {
            int allBooks = this.books.Where(b => b.ISBN == ISBN && !b.Removed).Count();
            int availableBooks = this.books.Where(b => b.ISBN == ISBN && b.Available && !b.Removed).Count();

            return $"We have {allBooks} copies of which {availableBooks} are available";
        }

        public string GetDistinctBooks()
        {
            List<IBook> books = this.books.Where(b => !b.Removed).GroupBy(x => x.ISBN).Select(group => group.First()).ToList();

            string message = "Books:" + System.Environment.NewLine;

            foreach (var book in books)
                message = message + $"{book.Name}" + System.Environment.NewLine;

            return message;
        }

        public string AddBook(IBook book)
        {
            List<IBook> books = this.books.ToList();
            book.Id = this.books.Length + 1;
            book.Available = true;

            books.Add(book);

            this.books = books.ToArray();

            return "Book added";
        }

        public string RemoveBookById(int Id)
        {
            this.books.SingleOrDefault(b => b.Id == Id).Removed = true;

            return "Book removed";
        }

        public string RemoveBookByISBN(long ISBN)
        {
            List<IBook> books = this.books.Where(b => b.ISBN == ISBN).ToList();
            books.ForEach(b => b.Removed = true);

            this.books = books.ToArray();

            return "Book removed";
        }

        private string ReturnMessage(IBook? book)
        {
            if (book == null)
                return "Book doesn't exist";

            return $"Book id: {book.Id}, ISBN: {book.ISBN}, full name: {book.Name}, author: {book.Author}, price: {book.Price}, available: {book.Available}";
        }
    }
}
