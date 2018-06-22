using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Challenge2.API.Models;

namespace Challenge2.API.Controllers
{
    public class BookingsOnlyController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/BookingsOnly
        public IQueryable<BookingsOnly> GetBookingsOnlies()
        {
            return db.BookingsOnlies;
        }

        // GET: api/BookingsOnly/5
        [ResponseType(typeof(BookingsOnly))]
        public async Task<IHttpActionResult> GetBookingsOnly(int id)
        {
            BookingsOnly bookingsOnly = await db.BookingsOnlies.FirstOrDefaultAsync(b => b.bookingID == id);
            if (bookingsOnly == null)
            {
                return NotFound();
            }

            return Ok(bookingsOnly);
        }

        // PUT: api/BookingsOnly/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingsOnly(int id, BookingsOnly bookingsOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingsOnly.bookingID)
            {
                return BadRequest();
            }

            db.Entry(bookingsOnly).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingsOnlyExists(id))
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

        // POST: api/BookingsOnly
        [ResponseType(typeof(BookingsOnly))]
        public async Task<IHttpActionResult> PostBookingsOnly(BookingsOnly bookingsOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookingsOnlies.Add(bookingsOnly);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingsOnlyExists(bookingsOnly.bookingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookingsOnly.bookingID }, bookingsOnly);
        }

        // DELETE: api/BookingsOnly/5
        [ResponseType(typeof(BookingsOnly))]
        public async Task<IHttpActionResult> DeleteBookingsOnly(int id)
        {
            BookingsOnly bookingsOnly = await db.BookingsOnlies.FindAsync(id);
            if (bookingsOnly == null)
            {
                return NotFound();
            }

            db.BookingsOnlies.Remove(bookingsOnly);
            await db.SaveChangesAsync();

            return Ok(bookingsOnly);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingsOnlyExists(int id)
        {
            return db.BookingsOnlies.Count(e => e.bookingID == id) > 0;
        }
    }
}