using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlsBookStore.Data.Models.ViewModels.Writer
{
    public class WriterBaseModel
    {

        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name="Author' Name")]
        public string Name { get; set; }
    }
}
