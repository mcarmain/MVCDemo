using MVCDemo.Models;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    [Authorize()]
    public class ItemController : Controller
    {
        private SampleDbContext db = new SampleDbContext();

        //Get: /Item/
     
        // Get: /Item/
    
        public ActionResult Index(string filter = null, int page = 1,
        int pageSize = 5, string sort = "Id", string sortdir = "ASC")
        {
            var records = new PagedList<Item>();
            ViewBag.filter = filter;

            records.Content = db.Items
                  .Where(x => filter == null ||
                      (x.Name.Contains(filter))
                       || x.Description.Contains(filter)
                       || x.ItemType.Name.Contains(filter)
                     )
                  .OrderBy(sort + " " + sortdir)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ToList();
            // Count
            records.TotalRecords = db.Items
              .Where(x => filter == null ||
                 (x.Name.Contains(filter)) || x.Description.Contains(filter)
                       || x.ItemType.Name.Contains(filter)).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;
            records.filter = filter;
            records.sort = sort;
            records.sortdir = sortdir;
            return View(records);
        }

        // GET: /Item/Details/5
        public ActionResult Details(int id = 0)
        {
            Item Item = db.Items.Find(id);
            if (Item == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", Item);
        }
        // GET: /Item/Create
        [HttpGet]
        public ActionResult Create()
        {
            var Item = new Item();
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Name", 1);
            return PartialView("Create", Item);
        }
        // POST: /Item/Create
        [HttpPost]
        public JsonResult Create(Item Item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(Item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(Item, JsonRequestBehavior.AllowGet);
        }
        // GET: /Item/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var Item = db.Items.Find(id);
            if (Item == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemTypeId = new SelectList(db.ItemTypes, "Id", "Name", Item.ItemTypeId);
            return PartialView("Edit", Item);
        }
        // POST: /Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ItemTypeId")] Item Item)
        {
            if (ModelState.IsValid) 
            {
                db.Entry(Item).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", Item);
        }
        // GET: /Item/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Item Item = db.Items.Find(id);
            if (Item == null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", Item);
        }
        //
        // POST: /Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Item = db.Items.Find(id);
            db.Items.Remove(Item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
    

}