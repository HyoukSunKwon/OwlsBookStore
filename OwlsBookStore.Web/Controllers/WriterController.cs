using OwlsBookStore.Data.Models.ViewModels.BookSeriese;
using OwlsBookStore.Data.Models.ViewModels.Writer;
using OwlsBookStore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OwlsBookStore.Web.Controllers
{
    public class WriterController : Controller
    {
        private readonly IOwlsBookStoreData db;

        public WriterController(IOwlsBookStoreData db)
        {
            this.db = db;
        }
        // GET: Writer
        public ActionResult Index()
        {
            var model = db.GetAllWriter();     
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(WriterBaseViewModel newWriter)
        {
            if (ModelState.IsValid)
            {
                var newWriterAdded = db.AddWriter(newWriter);

                if (newWriterAdded == null)
                {
                    return View(newWriter);
                }
                else
                {
                    return RedirectToAction("Details", new { id = newWriterAdded.Id });
                }
            }
            return View(newWriter);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.GetWriterById(id);
            //model.BookSeries = new ICollection<BookSeriesBaseViewModel>();
            //addedNewBookSeries.Writer = db.Writers.Find(newBookSeries.Writer.Id);
           

            if ( model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.GetWriterById(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(WriterBaseViewModel editWriter)
        {
            if(ModelState.IsValid)
            {
                var isWriterUpdated = db.EditWriter(editWriter);
                if(!isWriterUpdated)
                {
                    return View(editWriter);
                }
                else
                {
                    return RedirectToAction("Details", new { id = editWriter.Id });
                }
            }
            return View(editWriter);

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if( id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WriterBaseViewModel writer = db.GetWriterById(id);
            if(writer == null)
            {
                return HttpNotFound();
            }

            return View(writer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            WriterBaseViewModel writerToDeleted = db.GetWriterById(id);
            bool isDeleted = db.DeleteWriter(id);

            if(isDeleted)
            {
                return View("DeletedConfirm");
            }
            else
            {
                return View(writerToDeleted);
            }
        }

        [HttpGet]
        public ActionResult AddBookSeries(int? id)
        {
            var form = new BookSeriesAddFormViewModel();
            var genreList = db.GetAllGenre();
            form.Writer = db.GetWriterBaseInfoById(id);
            form.GenreList = new SelectList(genreList, "Name", "Name");
            return View(form);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[Route("Writer/AddBookSeries/{id}")]
        public ActionResult AddBookSeries(BookSeriesAddFormViewModel newBookSeries)
        {
            var genre = db.GetAllGenre();
            newBookSeries.GenreList = new SelectList(genre, "Name", "Name");
            if(ModelState.IsValid)
            {
                //newBookSeries.Id = 0;
                BookSeriesAddFormViewModel newBookSeriesAdded = db.AddBookSeries(newBookSeries);
                return RedirectToAction("Details", "BookSeries", new { newBookSeriesAdded.Id });

            }
            else
            {
                var genreList = db.GetAllGenre();
                newBookSeries.GenreList = new SelectList(genreList, "Name", "Name");
                return View(newBookSeries);
            }
        }

    }
}