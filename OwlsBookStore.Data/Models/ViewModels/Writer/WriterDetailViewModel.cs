using OwlsBookStore.Data.Models.EntityModels;
using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Writer
{
    public class WriterDetailViewModel : WriterBaseViewModel
    {
        public WriterDetailViewModel()
        {
            BookSerieses = new List<BookSeriesBaseViewModel>();
        }
        public ICollection<BookSeriesBaseViewModel> BookSerieses { get; set; }
    }
}
