using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    [Authorize]
    public class ItemTypesController : Controller
    {
        private DemoDbContext db = new DemoDbContext();

        // GET: ItemTypes
        public ActionResult Index()
        {
            return View(db.ItemTypes.ToList());
        }

        // GET: ItemTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        // GET: ItemTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                db.ItemTypes.Add(itemType);
                db.SaveChanges();
                var msg =string.Format("{0} created.", string.IsNullOrWhiteSpace(itemType.Name) ? "Type" : itemType.Name);
                TempData["Message"]=msg;
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        // GET: ItemTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            return View(itemType);
        }

        // POST: ItemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemType).State = EntityState.Modified;
                db.SaveChanges();
                var msg = string.Format("{0} saved.",string.IsNullOrWhiteSpace(itemType.Name) ? "Type" : itemType.Name);
                TempData["Message"] = msg;
                return RedirectToAction("Index");
            }
            return View(itemType);
        }

        // GET: ItemTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemType itemType = db.ItemTypes.Find(id);
            if (itemType == null)
            {
                return HttpNotFound();
            }
            if (db.Items.Where<Item>(i => i.ItemTypeId == id).Count()>0)
            {
                var msg = String.Format("Unable to delete {0} it is being used.",string.IsNullOrWhiteSpace(itemType.Name) ? "Type" : itemType.Name);
                TempData["Error"] = msg;
                return RedirectToAction("Index");
            }

            return View(itemType);
        }

        // POST: ItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemType itemType = db.ItemTypes.Find(id);
            if (db.Items.Where<Item>(i => i.ItemTypeId == id).Count() > 0)
            {
                var error = String.Format("Unable to delete {0} it is being used.", string.IsNullOrWhiteSpace(itemType.Name) ? "Type" : itemType.Name);
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            if (itemType != null)
            {
                var msg = string.Format("{0} deleted.", string.IsNullOrWhiteSpace(itemType.Name) ? "Type" : itemType.Name);
                TempData["Message"] = msg;
                db.ItemTypes.Remove(itemType);
                db.SaveChanges();
            }
            else
            {
                var error = String.Format("ItemTypeId={0} was not found.", id);
                TempData["Error"] = error;
            }
            return RedirectToAction("Index");
        }

        // GET: ItemTypes/CreateType/1
         public ActionResult CreateType(int id)
        {
            //Note the id being passed here is Item.Id of the item model that initiated
            //the create type call

           // TempData["CreateType"] = id;
            return View();
        }


        // Post: ItemTypes/Create
        [HttpPost, ActionName("CreateType")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateType(ItemType itemType)
        {
            //Note:
            //  itemType.Id has the item.Id 
            //  from the item that initiated the create type
            var x = itemType.Id;
            itemType.Id = 0;
            var item = db.Items.Find(x);
            itemType = db.ItemTypes.Add(itemType);
            db.SaveChanges();
            item.ItemTypeId = itemType.Id;
            db.SaveChanges();
            return RedirectToAction("Edit", "Items", new { item.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
