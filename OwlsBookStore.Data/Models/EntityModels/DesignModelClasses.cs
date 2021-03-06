using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OwlsBookStore.Data.Models.EntityModels
{
    public class Writer
    {
        public Writer()
        {
            BookSerieses = new List<BookSeries>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Portrayal { get; set; }

        public string UrlWriter { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<BookSeries> BookSerieses { get; set; }

    }

    public class BookSeries 
    {
        public BookSeries()
        {
            ReleaseDate = DateTime.Now;
            Books = new List<Book>();
        }
   
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlBookSeries { get; set; }
        public string Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Depiction { get; set; }
        public string Genre { get; set; }
        public virtual Writer Writer { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Genre 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Book
    {
        public Book()
        {
            BookSerieses = new BookSeries();
            ReleaseDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlBook { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Depiction { get; set; }

        public BookSeries BookSerieses { get; set; }
        public Writer Writer { get; set; }

    }
}
