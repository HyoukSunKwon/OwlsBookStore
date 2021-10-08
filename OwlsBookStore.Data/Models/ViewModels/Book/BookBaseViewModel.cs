using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Book
{
    public class BookBaseViewModel : BookBaseModel
    {
        public string UrlBook{ get; set; }
        public DateTime? ReleseDate { get; set; }

        public BookSeriesBaseViewModel BookSeries { get; set; }
    }
}
