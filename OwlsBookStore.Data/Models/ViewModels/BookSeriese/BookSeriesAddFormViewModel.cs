using OwlsBookStore.Data.Models.ViewModels.Writer;
using System.Web.Mvc;

namespace OwlsBookStore.Data.Models.ViewModels.BookSeriese
{
    public class BookSeriesAddFormViewModel : BookSeriesBaseViewModel
    {

        public SelectList GenreList { get; set; }
    }
}
