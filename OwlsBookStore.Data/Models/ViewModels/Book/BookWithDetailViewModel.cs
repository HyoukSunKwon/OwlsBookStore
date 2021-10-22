using OwlsBookStore.Data.Models.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Book
{
    public class BookWithDetailViewModel : BookBaseViewModel
    {
        public WriterBaseModel Writer { get; set; }
    }
}
