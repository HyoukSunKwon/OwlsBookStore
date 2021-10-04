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

        [Required, StringLength(50)]
        public string Name { get; set; }

        public string Portrayal { get; set; }

        public string UrlWriter { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<BookSeries> BookSerieses { get; set; }

    }

    public class BookSeries 
    {
        public BookSeries()
        {
            Genre = new Genre();
            Writer = new Writer();
            Book = new List<Book>();
        }

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlBookSeries { get; set; }
        public string Publisher { get; set; }
        public string Dipiction { get; set; }

        public Genre Genre { get; set; }
        public Writer Writer { get; set; }
        public ICollection<Book> Book { get; set; }
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
            BookSeries = new BookSeries();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlBook { get; set; }
        public DateTime ReleaseDate { get; set; }

        public BookSeries BookSeries { get; set; }

    }
}
