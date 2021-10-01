using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Writer
{
    public class WriterBaseViewModel : WriterBaseModel
    {
        public string UrlWriter { get; set; }
        public DateTime BirthDate { get; set; }
        public string Potrayal { get; set; }
    }
}
