using AutoMapper;
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

        //public IEnumerable<Book> GetAllBooks()
        //{
        //    return db.books.ToList();
        //}


    }
}
