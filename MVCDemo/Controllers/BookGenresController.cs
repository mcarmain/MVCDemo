using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class BookGenresController : ApiController
    {
        private SampleDbContext db = new SampleDbContext();

        // GET: api/BookGenres
        public IQueryable<BookGenre> GetBookGenres()
        {
            return db.BookGenres;
        }

        // GET: api/BookGenres/5
        [ResponseType(typeof(BookGenre))]
        public IHttpActionResult GetBookGenre(int id)
        {
            BookGenre bookGenre = db.BookGenres.Find(id);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return Ok(bookGenre);
        }

        // PUT: api/BookGenres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookGenre(int id, BookGenre bookGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookGenre.Id)
            {
                return BadRequest();
            }

            db.Entry(bookGenre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookGenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BookGenres
        [ResponseType(typeof(BookGenre))]
        public IHttpActionResult PostBookGenre(BookGenre bookGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookGenres.Add(bookGenre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookGenre.Id }, bookGenre);
        }

        // DELETE: api/BookGenres/5
        [ResponseType(typeof(BookGenre))]
        public IHttpActionResult DeleteBookGenre(int id)
        {
            BookGenre bookGenre = db.BookGenres.Find(id);
            if (bookGenre == null)
            {
                return NotFound();
            }

            db.BookGenres.Remove(bookGenre);
            db.SaveChanges();

            return Ok(bookGenre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookGenreExists(int id)
        {
            return db.BookGenres.Count(e => e.Id == id) > 0;
        }
    }
}