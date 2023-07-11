using Library.Interfaces;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using System;
using System.Linq;

namespace LibraryManagement
{
    public class DbMock : IDbMock
    {
        public IUser[] Users { get; set; }

        public IBook[] Books { get; set; }

        public IRental[] Rentals { get; set; }

        public DbMock()
        {
            SetUsers();
            SetBooks();
            SetRentals();
        }

        private void SetUsers()
        {
            this.Users = new User[]
            {
                 new User()
                 {
                    Id = 1,
                    FullName = "Andrei Teodorescu"
                 },
                 new User()
                 {
                    Id = 2,
                    FullName = "Cristian Indries"
                 },
                 new User()
                 {
                    Id = 3,
                    FullName = "Bogdan Toma"
                 },
            };
        }

        private void SetBooks()
        {
            this.Books = new Book[]
            {
                new Book()
                {
                    Id = 1,
                    ISBN = 0458144576,
                    Name= "Ursul pacalit de vulpe",
                    Author ="Ion Creanga",
                    Price = 10.0,
                    Available = false
                },
                new Book()
                {
                    Id = 2,
                    ISBN = 0923644768,
                    Name= "Ion",
                    Author ="Liviu Rebreanu",
                    Price = 15.0,
                    Available = false
                },
                new Book()
                {
                    Id = 3,
                    ISBN = 0458144576,
                    Name= "Ursul pacalit de vulpe",
                    Author ="Ion Creanga",
                    Price = 10.0,
                    Available = true
                },
            };
        }

        private void SetRentals()
        {
            this.Rentals = new Rental[]
            {
                new Rental()
                {
                    Id = 1,
                    User = this.Users.Single(u => u.Id == 1),
                    Book = this.Books.Single(u => u.Id == 1),
                    RentalDate = new DateTime(2023, 07, 1),
                    BookReturned = false
                },
                new Rental()
                {
                    Id = 2,
                    User = this.Users.Single(u => u.Id == 2),
                    Book = this.Books.Single(u => u.Id == 2),
                    RentalDate = new DateTime(2023, 06, 20),
                    BookReturned = false
                },
            };
        }
    }
}
