using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using OwlsBookStore.Data.Models.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Book
{
    public class AddBookListModel : BookBaseModel
    {
        public string UrlBook { get; set; }
        public DateTime? ReleseDate { get; set; }
        public string Depiction { get; set; }
        public BookSeriesBaseModel BookSerieses { get; set; }
        public WriterBaseModel Writer { get; set; }
    }
}
