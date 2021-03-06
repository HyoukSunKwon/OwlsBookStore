using OwlsBookStore.Data.Models.EntityModels;
using OwlsBookStore.Data.Models.ViewModels.Writer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.BookSeriese
{
    public class BookSeriesBaseViewModel : BookSeriesBaseModel
    {

        public BookSeriesBaseViewModel()
        {
            ReleaseDate = DateTime.Now;
        }
        [Display(Name="Image Of Book Series")]
        public string UrlBookSeries { get; set; }

        [Display(Name="Book Publisher")]
        public string Publisher { get; set; }
        public string Genre { get; set; }
        
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Depiction { get; set; }

        public WriterBaseModel Writer { get; set; }

    }
}
