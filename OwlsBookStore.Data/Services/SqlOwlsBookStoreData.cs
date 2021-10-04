using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public class SqlOwlsBookStoreData : IOwlsBookStoreData
    {
        private readonly OwlsBookStoreDbContext db;

        public SqlOwlsBookStoreData(OwlsBookStoreDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Writer> GetAll() 
        {
            return db.writers.ToList();
        }
        
        public IEnumerable<Book> GetAllBooks()
        {
            return db.books.ToList();
        }
    }
}
