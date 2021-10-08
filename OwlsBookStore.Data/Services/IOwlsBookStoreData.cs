using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using OwlsBookStore.Data.Models.ViewModels.Genre;
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
        WriterBaseViewModel GetWriterBaseInfoById(int? id);
        WriterDetailViewModel GetWriterById(int? id);
        bool EditWriter(WriterBaseViewModel editedWriter);
        bool DeleteWriter(int? id);
        IEnumerable<GenreBaseModel> GetAllGenre();
        IEnumerable<BookSeriesBaseViewModel> GetAllBookSeries();
        BookSeriesAddFormViewModel AddBookSeries(BookSeriesAddFormViewModel newBookSeries);
        BookSeriesBaseViewModel GetBookSeriesById(int? id);

        //IEnumerable<Book> GetAllBooks();
    }
}
