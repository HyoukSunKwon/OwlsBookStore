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
        
        //public IEnumerable<Book> GetAllBooks()
        //{
        //    return db.books.ToList();
        //}


    }
}
