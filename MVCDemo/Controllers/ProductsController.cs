using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MVCDemo.WebApi.Models;
namespace MVCDemo.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private DataContext db = new DataContext();
        // GET api/ Products 

        public IEnumerable<Product> GetProducts()
        {
           
            return db.Products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT api/ Products/ 5 
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (ModelState.IsValid && id == product.ID)
            {
                db.Entry(product).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // POST api/ Products 
        public IHttpActionResult PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                var uri = new Uri(Url.Link("DefaultApi", new { id = product.ID }));
                return Created(uri, product);
            }
            else {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/ Products/ 5 
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null) { return NotFound(); }

            try
            {
                db.Products.Remove(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok(product);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    

    }
}
            



