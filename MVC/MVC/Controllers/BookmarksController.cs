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
    [Authorize]
    public class BookmarksController : Controller
    {
        IBookmarkService _bookmarkService;

        public BookmarksController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        // GET: Bookmarks
        public ActionResult Index()
        {
            List<Bookmark> bookmarksModel = _bookmarkService.GetBookmarks();

            return View(bookmarksModel);
        }

        // GET: Bookmarks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);

            if (bookmark == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                bookmark.CreateDate = DateTime.Now;         // current datetime as default
                _bookmarkService.CreateBookmark(bookmark);

                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                bookmark.CreateDate = DateTime.Now;     // It has to be set like this, otherwise it sets the time to 0001/01/01 which is outside of the range of the SQL server
                _bookmarkService.UpdateBookmark(bookmark);

                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmark((int)id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmark(id);

            _bookmarkService.DeleteBookmark(bookmark);

            return RedirectToAction("Index");
        }
    }
}
