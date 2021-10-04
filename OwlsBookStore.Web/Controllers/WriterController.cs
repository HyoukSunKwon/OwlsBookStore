using OwlsBookStore.Data.Models.ViewModels.Writer;
using OwlsBookStore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}