using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
namespace MVCDemo.Controllers
{
    public class ClearController : Controller
    {
        // GET: Clear
        public ActionResult Index()
        {
            ClearModel c = new ClearModel();
            return PartialView(c);
        }
        // POST: /Item/Create
        [HttpPost]
        public ActionResult Index(ClearModel Item)
        {
         //   if (ModelState.IsValid)
           // {
               // db.Items.Add(Item);
              //  db.SaveChanges();
             //   return Json(new { success = true });
            //}
            //  return Json(Item, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}