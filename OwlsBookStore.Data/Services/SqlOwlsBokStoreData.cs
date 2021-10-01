using OwlsBookStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public class SqlOwlsBokStoreData : IOwlsBookStoreData
    {
        private readonly OwlsBookStoreDbContext db;

        public SqlOwlsBokStoreData(OwlsBookStoreDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Writer> GetAll()
        {
            return from w in db.writers
                   orderby w.Name
                   select w;
        }
    }
}
