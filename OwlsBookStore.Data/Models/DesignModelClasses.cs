using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OwlsBookStore.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            BookSerieses = new List<BookSeries>();
        }

        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }

        [Display(Name="Author's Photo")]
        public string UrlWriter { get; set; }

        [Display(Name="Author's Birth Date")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
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

        [Display(Name="Book Series Title")]
        public string Name { get; set; }
        public string UrlBookSeries { get; set; }

        [Display(Name="Book Publishing Company")]
        public string Publisher { get; set; }

        [DataType(DataType.MultilineText)]
        public string Depiction { get; set; }

        public Genre Genre { get; set; }
        public Writer Writer { get; set; }
        public ICollection<Book> Book { get; set; }
    }

    public class Genre 
    {
        public int Id { get; set; }

        [Display(Name="Genre")]
        public string Name { get; set; }
    }

    public class Book
    {
        public Book()
        {
            BookSeries = new BookSeries();
        }
        public int Id { get; set; }

        [Display(Name="Book Title")]
        public string Name { get; set; }

        [Display(Name="Book Image")]
        public string UrlBook { get; set; }

        [Display(Name="Book Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Book Seriese")]
        public BookSeries BookSeries { get; set; }

    }
}
