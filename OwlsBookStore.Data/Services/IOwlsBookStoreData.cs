using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public interface IOwlsBookStoreData
    {
        IEnumerable<Writer> GetAll();

        IEnumerable<Book> GetAllBooks();
    }
}
