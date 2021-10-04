using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Writer
{
    public class WriterBaseViewModel : WriterBaseModel
    {
        [Display(Name="Autor's Picture")]
        [Required]
        public string UrlWriter { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Birth Date")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Potrayal { get; set; }
    }
}
