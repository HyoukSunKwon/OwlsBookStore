using AutoMapper;
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
               cfg.CreateMap<WriterBaseModel, Writer>();
               cfg.CreateMap<Writer, WriterBaseModel>();

               cfg.CreateMap<BookSeries, BookSeriesBaseModel>();
               cfg.CreateMap<BookSeries, BookSeriesBaseViewModel>();
               cfg.CreateMap<BookSeries, BookSeriesAddFormViewModel>();
               cfg.CreateMap<BookSeriesAddFormViewModel, BookSeries>();
               cfg.CreateMap<BookSeriesBaseViewModel, BookSeries>();
               cfg.CreateMap<BookSeriesAddFormViewModel, Writer>();

               cfg.CreateMap<Genre, GenreBaseModel>();
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

        public WriterBaseViewModel GetWriteById(int? id)
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
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBaseModel>>(db.Genres.OrderBy(bs => bs.Name));
        }

        public IEnumerable<BookSeriesBaseViewModel> GetAllBookSeries()
        {
            return mapper.Map<IEnumerable<BookSeries>, IEnumerable<BookSeriesBaseViewModel>>(db.BookSerieses.OrderBy(bs => bs.Name));
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

        public BookSeriesBaseViewModel GetBookSeriesById(int? id)
        {
            var bookSeries = db.BookSerieses.FirstOrDefault(bs => bs.Id == id);
            return bookSeries == null ? null : mapper.Map<BookSeries, BookSeriesBaseViewModel>(bookSeries);
        }
    }
        
}
