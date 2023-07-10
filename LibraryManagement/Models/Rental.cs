using LibraryManagement.Interfaces;
using System;

namespace LibraryManagement.Models
{
    public class Rental : IRental
    {
        public int Id { get; set; }

        public IBook Book { get; set; }

        public IUser User { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get => this.RentalDate.AddDays(14); }

        public bool BookReturned { get; set; }

        public int GetOverdueDays(DateTime currentDate)
        {
            return currentDate.Subtract(this.ReturnDate).Days;
        }

        public double GetPenalty(DateTime currentDate)
        {
            int diffOfDates = currentDate.Subtract(this.ReturnDate).Days;
            double penalty = 0.01 * this.Book.Price;

            return penalty * diffOfDates;
        }

        public double GetFullPrice(DateTime currentDate)
        {
            int diffOfDates = currentDate.Subtract(this.ReturnDate).Days;
            double penalty = 0.01 * this.Book.Price;

            return penalty * diffOfDates + this.Book.Price;
        }
    }
}
