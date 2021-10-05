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
            var model = db.GetWriteById(id);

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

            var model = db.GetWriteById(id);
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

            WriterBaseViewModel writer = db.GetWriteById(id);
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

            WriterBaseViewModel writerToDeleted = db.GetWriteById(id);
            bool isDeleted = db.DeleteWriter(id);

            if(isDeleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(writerToDeleted);
            }
        }

        public ActionResult AddBookSeries(int? id)
        {

        }
    }
}