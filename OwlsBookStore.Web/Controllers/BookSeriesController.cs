using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if( id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var model = db.GetBookSeriesAddFormInfo(id);
            if( model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(BookSeriesAddFormViewModel editBookSeries)
        {
            if( ModelState.IsValid)
            {
                var isEdittedBookSeries = db.EditBookSeries(editBookSeries);
                
                if( ! isEdittedBookSeries)
                {
                    return View(editBookSeries);
                }
                else
                {
                    return RedirectToAction("Details", new { id = editBookSeries.Id });
                }
            }

            return View(editBookSeries);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            BookSeriesBaseViewModel bookSeries = db.GetbookSeriesBaseInfoById(id);
            if(bookSeries == null)
            {
                return HttpNotFound();
            }

            return View(bookSeries);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfrim(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            BookSeriesBaseViewModel bookSeriesToDeleted = db.GetbookSeriesBaseInfoById(id);
            bool isDeleted = db.DeleteBookSeries(id);

            if( isDeleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(bookSeriesToDeleted);
            }

        }

    }
}