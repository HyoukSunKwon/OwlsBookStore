using AutoMapper;
using OwlsBookStore.Data.Models;
using OwlsBookStore.Data.Models.EntityModels;
using OwlsBookStore.Data.Models.ViewModels.Book;
using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using OwlsBookStore.Data.Models.ViewModels.Genre;
using OwlsBookStore.Data.Models.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Services
{
    public class SqlOwlsBookStoreData : IOwlsBookStoreData
    {
        private readonly OwlsBookStoreDbContext db;
        public IMapper mapper;

        public SqlOwlsBookStoreData(OwlsBookStoreDbContext db)
        {
            this.db = db;

            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<Writer, WriterBaseViewModel>();
               cfg.CreateMap<WriterBaseViewModel, Writer>();
               cfg.CreateMap<Writer, WriterBaseModel>().ReverseMap();
               cfg.CreateMap<Writer, WriterDetailViewModel>();

               cfg.CreateMap<BookSeries, BookSeriesBaseModel>();
               cfg.CreateMap<BookSeries, BookSeriesWithDetailViewModel>();
               cfg.CreateMap<BookSeries, BookSeriesAddFormViewModel>();
               cfg.CreateMap<BookSeries, BookSeriesBaseViewModel>();
               cfg.CreateMap<BookSeriesBaseViewModel, BookSeries>();
               cfg.CreateMap<BookSeriesAddFormViewModel, BookSeries>();

               cfg.CreateMap<Genre, GenreBaseModel>().ReverseMap();

               cfg.CreateMap<Book, BookBaseModel>();
               cfg.CreateMap<Book, BookBaseViewModel>();

           });

            mapper = config.CreateMapper();
            db.Configuration.ProxyCreationEnabled = false;
        }

        
        public WriterBaseViewModel AddWriter(WriterBaseViewModel newWriter)
        {
            var addedWriter = db.Writers.Add(mapper.Map<WriterBaseViewModel, Writer>(newWriter));
            db.SaveChanges();

            return addedWriter == null ? null : mapper.Map<Writer, WriterBaseViewModel>(addedWriter);

        }

        public IEnumerable<WriterBaseViewModel> GetAllWriter() 
        {
            return mapper.Map<IEnumerable<Writer>, IEnumerable<WriterBaseViewModel>>(db.Writers.OrderBy(w => w.Name));
        }

        public WriterDetailViewModel GetWriterById(int? id)
        {
            var writer = db.Writers.Include(i => i.BookSerieses).FirstOrDefault(w => w.Id == id);
            //var writer = db.Writers.Include(i => i.).FirstOrDefault(w => w.Id == id);
            //writer.BookSerieses = db.BookSerieses.Finsd(writer.Id);
            //addedNewBookSeries.Writer = db.Writers.Find(newBookSeries.Writer.Id);
            return writer == null ? null : mapper.Map<Writer, WriterDetailViewModel>(writer);
        }

        public WriterBaseViewModel GetWriterBaseInfoById(int? id)
        {
            var writer = db.Writers.FirstOrDefault(w => w.Id == id);
            return writer == null ? null : mapper.Map<Writer, WriterBaseViewModel>(writer);
        }


        public bool EditWriter(WriterBaseViewModel editedWriter)
        {
            bool updated = false;
            var writerFound = db.Writers.Find(editedWriter.Id);
            if(writerFound != null)
            {
                db.Entry(writerFound).CurrentValues.SetValues(editedWriter);
                var saved = db.SaveChanges();

                updated = saved > 0;
            }

            return updated;

        }

        public bool DeleteWriter(int? id)
        {
            bool delete = false;
            var writerFound = db.Writers.Find(id);
            if(writerFound == null)
            {
                return false;
            }
            else
            {
                db.Writers.Remove(writerFound);
                var save = db.SaveChanges();

                return delete = save > 0;
            }
        }

        public IEnumerable<GenreBaseModel> GetAllGenre()
        {
            var genre_list = db.Genres.OrderBy(bs => bs.Name);
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBaseModel>>(genre_list);
        }

        public IEnumerable<BookSeriesWithDetailViewModel> GetAllBookSeries()
        {
            var bookSerieses = db.BookSerieses.Include(b=> b.Writer).OrderBy(bs => bs.Name);
            return mapper.Map<IEnumerable<BookSeries>, IEnumerable<BookSeriesWithDetailViewModel>>(bookSerieses);
        }

        public BookSeriesAddFormViewModel AddBookSeries(BookSeriesAddFormViewModel newBookSeries)
        {
            var addedNewBookSeries = mapper.Map<BookSeriesAddFormViewModel, BookSeries>(newBookSeries);
            //addedNewBookSeries.ReleaseDate = DateTime.Now;
            addedNewBookSeries.Writer = db.Writers.Find(newBookSeries.Writer.Id);
            db.BookSerieses.Add(addedNewBookSeries);

            db.SaveChanges();

            return addedNewBookSeries == null ? null : mapper.Map<BookSeries, BookSeriesAddFormViewModel>(addedNewBookSeries);
        }

        public BookSeriesWithDetailViewModel GetBookSeriesById(int? id)
        {
            //var bookSeries = db.BookSerieses.FirstOrDefault(bs => bs.Id == id);
            //
            var bookSeries = db.BookSerieses.Include(w => w.Writer).Include( b => b.Books).FirstOrDefault(bs => bs.Id == id);
            //bookSeries.Writer = db.Writers.Find(bookSeries.Writer.Id);
            return bookSeries == null ? null : mapper.Map<BookSeries, BookSeriesWithDetailViewModel>(bookSeries);
        }


        public bool EditBookSeries(BookSeriesAddFormViewModel editBookSeries)
        {
            bool updated = false;
            var bookSeriesFound = db.BookSerieses.Find(editBookSeries.Id);
            if( bookSeriesFound != null)
            {
                db.Entry(bookSeriesFound).CurrentValues.SetValues(editBookSeries);
                //bookSeriesFound.ReleaseDate = DateTime.Now;
                var saved = db.SaveChanges();
                updated = saved > 0;
            }

            return updated;
        }

        public bool DeleteBookSeries(int? id)
        {
            bool delete = false;
            var bookSeriesFound = db.BookSerieses.Find(id);
            if(bookSeriesFound == null)
            {
                return delete;
            }
            else
            {
                bookSeriesFound.ReleaseDate = DateTime.Now;
                db.BookSerieses.Remove(bookSeriesFound);
                var save = db.SaveChanges();

                return delete = save > 0;
            }
        }

        public BookSeriesBaseViewModel GetbookSeriesBaseInfoById(int? id)
        {
            var bookSeries = db.BookSerieses.Include(w => w.Writer).FirstOrDefault(bs => bs.Id == id);
            return bookSeries == null ? null : mapper.Map<BookSeries, BookSeriesBaseViewModel>(bookSeries);
        }

        public BookSeriesAddFormViewModel GetBookSeriesAddFormInfo(int? id)
        {
            var bookSeries = db.BookSerieses.Include(w => w.Writer).FirstOrDefault(bs => bs.Id == id);
            return bookSeries == null ? null : mapper.Map<BookSeries, BookSeriesAddFormViewModel>(bookSeries);
        }

    }
        
}
