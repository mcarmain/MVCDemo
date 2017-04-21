using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
namespace MVCDemo.Controllers
{
    [Authorize()]
    public class ClearController : Controller
    {
        // GET: Clear/Index
        [HttpGet]
        public ActionResult Clear()
        {
            ClearModel c = new ClearModel();
            c.Clear = "N";
            return PartialView(c);
        }
        // POST: /Clear/Index
        [HttpPost, ActionName("Clear")]
        public ActionResult ClearConfirmed(ClearModel Item)
        {
            if (ModelState.IsValid)
            {

                SampleDbContext context = new SampleDbContext();
                context.Database.Delete();
                context.Database.Initialize(true);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(Item, JsonRequestBehavior.AllowGet);
        }
    }
}