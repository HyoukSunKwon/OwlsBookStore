using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public class OwlsBookStoreDbContext : DbContext
    {
        public OwlsBookStoreDbContext() : base("OwlsBookStoreDbContext") 
        {}
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookSeries> BookSerieses { get; set; }
        public DbSet<Book> Books { get; set; }

        public System.Data.Entity.DbSet<OwlsBookStore.Data.Models.ViewModels.BookSeriese.BookSeriesBaseViewModel> BookSeriesBaseViewModels { get; set; }

        public System.Data.Entity.DbSet<OwlsBookStore.Data.Models.ViewModels.Book.BookBaseViewModel> BookBaseViewModels { get; set; }
    }
}
