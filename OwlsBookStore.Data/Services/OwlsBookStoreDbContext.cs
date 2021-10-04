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
        public DbSet<Writer> writers { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<BookSeries> bookSerieses { get; set; }
        public DbSet<Book> books { get; set; }

    }
}
