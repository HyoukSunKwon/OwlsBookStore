using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using OwlsBookStore.Data.Models.ViewModels.Book;
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
        IEnumerable<BookSeriesWithDetailViewModel> GetAllBookSeries();
        BookSeriesAddFormViewModel AddBookSeries(BookSeriesAddFormViewModel newBookSeries);
        BookSeriesWithDetailViewModel GetBookSeriesById(int? id);
        bool EditBookSeries(BookSeriesAddFormViewModel editBookSeries);
        bool DeleteBookSeries(int? id);
        BookSeriesBaseViewModel GetbookSeriesBaseInfoById(int? id);
        BookSeriesAddFormViewModel GetBookSeriesAddFormInfo(int? id);
        IEnumerable<BookBaseViewModel> GetAllBooks();
        //AddBookListModel AddBookList(AddBookListModel newBook);

        BookBaseViewModel AddBookList(BookBaseViewModel newBook);
        BookBaseViewModel GetBookBaseInfoById(int id);
    }
}
