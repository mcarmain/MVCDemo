using MVCDemo.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize()]
    public class TaskController : Controller
    {
        // GET: Task
        private SampleDbContext db = new SampleDbContext();
        // GET: /Task/
        public ActionResult Index(string filter = null, int page = 1,
        int pageSize = 10, string sort = "Id", string sortdir = "ASC")
        {
            var records = new PagedList<Task>();
            ViewBag.filter = filter;
            records.Content = db.Tasks
                  .Where(x => filter == null ||
                      (x.Name.Contains(filter)
                       || x.Description.Contains(filter)
                        || x.Artifacts.Contains(filter)
                         || x.Dependencies.Contains(filter)
                          || x.Owner.Contains(filter))
                     )
                  .OrderBy(sort + " " + sortdir)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ToList();

            // Count
            records.TotalRecords = db.Tasks
                .Where(x => filter == null ||
                  (x.Name.Contains(filter)
                    || x.Description.Contains(filter)
                        || x.Artifacts.Contains(filter)
                         || x.Dependencies.Contains(filter)
                          || x.Owner.Contains(filter))).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }

        // GET: /Task/Details/5
        public ActionResult Details(int id = 0)
        {
            Task Task = db.Tasks.Find(id);
            if (Task == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", Task);
        }
        // GET: /Task/Create
        [HttpGet]
        public ActionResult Create()
        {
            var Task = new Task();
            return PartialView("Create", Task);
        }
        // POST: /Task/Create
        [HttpPost]
        public JsonResult Create(Task Task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(Task);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(Task, JsonRequestBehavior.AllowGet);
        }
        // GET: /Task/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var Task = db.Tasks.Find(id);
            if (Task == null)
            {
                return HttpNotFound();
            }
          
            return PartialView("Edit", Task);
        }
        // POST: /Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Points,Artifacts,Owner,Dependencies,Complete")] Task Task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Task).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", Task);
        }
        // GET: /Task/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Task Task = db.Tasks.Find(id);
            if (Task == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", Task);
        }
        //
        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Task = db.Tasks.Find(id);
            db.Tasks.Remove(Task);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }


}