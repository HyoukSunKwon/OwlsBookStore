using OwlsBookStore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwlsBookStore.Web.Controllers
{
    public class BookSeriesController : Controller
    {
        private readonly IOwlsBookStoreData db;

        public BookSeriesController(IOwlsBookStoreData db)
        {
            this.db = db;
        }

        // GET: BookSeries
        public ActionResult Index()
        {
            var model = db.GetAllBookSeries();
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if( id == null )
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var model = db.GetBookSeriesById(id);
            if( model == null )
            {
                return HttpNotFound();
            }

            return View(model);
        }
    }
}