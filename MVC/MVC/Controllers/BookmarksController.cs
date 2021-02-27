using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ReadLater.Entities;
using ReadLater.Services;

namespace MVC.Controllers
{
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;

        public BookmarksController(IBookmarkService bookmarkService)
        {
            this._bookmarkService = bookmarkService;
        }

        // GET: Bookmarks
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bookmarks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bookmarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
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

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bookmarks/Edit/5
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

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bookmarks/Delete/5
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
