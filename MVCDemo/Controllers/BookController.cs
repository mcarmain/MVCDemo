using MVCDemo.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize()]
    public class BookController : Controller
    {
        // GET: Book
        private SampleDbContext db = new SampleDbContext();
        // GET: /Book/
        public ActionResult Index(string filter = null, int page = 1,
        int pageSize = 5, string sort = "Id", string sortdir = "ASC")
        {
            var records = new PagedList<Book>();
            ViewBag.filter = filter;
            records.Content = db.Books
                  .Where(x => filter == null ||
                      (x.Title.Contains(filter))
                       || x.Summary.Contains(filter)
                       || x.BookGenre.Name.Contains(filter)
                     )
                  .OrderBy(sort + " " + sortdir)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ToList();

            // Count
            records.TotalRecords = db.Books
              .Where(x => filter == null ||
                 (x.Title.Contains(filter)) || x.Summary.Contains(filter)
                       || x.BookGenre.Name.Contains(filter)).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: /Book/Details/5
        public ActionResult Details(int id = 0)
        {
            Book Book = db.Books.Find(id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", Book);
        }
        // GET: /Book/Create
        [HttpGet]
        public ActionResult Create()
        {
            var Book = new Book();
            ViewBag.BookGenreId = new SelectList(db.BookGenres, "Id", "Name", 1);
            return PartialView("Create", Book);
        }
        // POST: /Book/Create
        [HttpPost]
        public JsonResult Create(Book Book)
        {
            var genre = db.BookGenres.Find(Book.BookGenreId);
            Book.BookGenre = genre;
            if (ModelState.IsValid)
            {
                db.Books.Add(Book);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(Book, JsonRequestBehavior.AllowGet);
        }
        // GET: /Book/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var Book = db.Books.Find(id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookGenreId = new SelectList(db.BookGenres, "Id", "Name", Book.BookGenreId);
            return PartialView("Edit", Book);
        }
        // POST: /Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Summary,Author,Publisher,BookGenreId")] Book Book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Book).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", Book);
        }
        // GET: /Book/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Book Book = db.Books.Find(id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", Book);
        }
        //
        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Book = db.Books.Find(id);
            db.Books.Remove(Book);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }


}