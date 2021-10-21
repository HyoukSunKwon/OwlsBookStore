using OwlsBookStore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwlsBookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IOwlsBookStoreData db;

        public BookController(IOwlsBookStoreData db)
        {
            this.db = db;
        }
        // GET: BookList
        public ActionResult Index()
        {
            var model = db.GetAllBooks();
            return View(model);
        }

        // GET: BookList/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetBookBaseInfoById(id);
            return View(model);
        }

        // GET: BookList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
