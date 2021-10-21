using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.BookSeriese
{
    public class BookSeriesBaseModel
    {
        public int Id { get; set; }

        //[Required, StringLength(50)]
        [Display(Name="Book Seriese Name")]
        public string Name { get; set; }
    }
}
