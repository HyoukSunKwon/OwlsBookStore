using OwlsBookStore.Data.Models.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.BookSeriese
{
    public class BookSeriesWithDetailViewModel : BookSeriesBaseViewModel
    {

        public ICollection<BookBaseViewModel> Books { get; set; }
    }
}
