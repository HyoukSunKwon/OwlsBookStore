using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using OwlsBookStore.Data.Models.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public interface IOwlsBookStoreData
    {
        IEnumerable<WriterBaseViewModel> GetAllWriter();

        WriterBaseViewModel AddWriter(WriterBaseViewModel writer);
        WriterBaseViewModel GetWriteById(int? id);
        bool EditWriter(WriterBaseViewModel editedWriter);
        bool DeleteWriter(int? id);

        //IEnumerable<Book> GetAllBooks();
    }
}
