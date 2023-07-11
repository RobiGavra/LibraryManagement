using LibraryManagement.Models;
using System;

namespace LibraryTest
{
    public static class DataMock
    {
        public static User[] MockUsers()
        {
            return new User[]
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

        public static Book[] MockBooks()
        {
            return new Book[]
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

        public static Rental[] MockRentals()
        {
            return new Rental[]
            {
                new Rental()
                {
                    Id = 1,
                    User = new User()
                    {
                        Id = 1,
                        FullName = "Andrei Teodorescu"
                    },
                    Book = new Book()
                    {
                        Id = 1,
                        ISBN = 0458144576,
                        Name= "Ursul pacalit de vulpe",
                        Author ="Ion Creanga",
                        Price = 10.0,
                        Available = false
                    },
                    RentalDate = new DateTime(2023, 07, 1),
                    BookReturned = false
                },
                new Rental()
                {
                    Id = 2,
                    User = new User()
                    {
                        Id = 2,
                        FullName = "Cristian Indries"
                    },
                    Book = new Book()
                    {
                        Id = 2,
                        ISBN = 0923644768,
                        Name= "Ion",
                        Author ="Liviu Rebreanu",
                        Price = 15.0,
                        Available = false
                    },
                    RentalDate = new DateTime(2023, 03, 01),
                    BookReturned = false
                },
            };
        }
    }
}
