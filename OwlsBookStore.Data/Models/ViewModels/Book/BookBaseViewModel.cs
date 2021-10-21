using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using OwlsBookStore.Data.Models.ViewModels.Genre;
using OwlsBookStore.Data.Models.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Book
{
    public class BookBaseViewModel : BookBaseModel
    {
        public BookBaseViewModel()
        {
            ReleseDate = DateTime.Now;
        }
        [Display(Name="Book Image")]
        public string UrlBook{ get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? ReleseDate { get; set; }
        public string Genre { get; set; }

        [Display(Name="Book Series")]
        public BookSeriesBaseViewModel BookSerieses { get; set; }
        public WriterBaseModel Writer { get; set; }
    }
}
