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
            // Get entity Model
            var model = db.GetAll();                     

            // Map from entity model to View Model
            // Mapper.Map<EntityWriter, ViewWriter>();

            // return view Model
            return View(model);
        }
    }
}