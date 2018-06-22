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
    public class TourEventsOnlyController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/TourEventsOnly
        public IQueryable<TourEventsOnly> GetTourEventsOnlies()
        {
            return db.TourEventsOnlies;
        }

        // GET: api/TourEventsOnly/5
        [ResponseType(typeof(TourEventsOnly))]
        public async Task<IHttpActionResult> GetTourEventsOnly(int id)
        {
            TourEventsOnly tourEventsOnly = await db.TourEventsOnlies.FirstOrDefaultAsync(te => te.eventID == id);
            if (tourEventsOnly == null)
            {
                return NotFound();
            }

            return Ok(tourEventsOnly);
        }

        // PUT: api/TourEventsOnly/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTourEventsOnly(int id, TourEventsOnly tourEventsOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tourEventsOnly.eventDay)
            {
                return BadRequest();
            }

            db.Entry(tourEventsOnly).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourEventsOnlyExists(id))
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

        // POST: api/TourEventsOnly
        [ResponseType(typeof(TourEventsOnly))]
        public async Task<IHttpActionResult> PostTourEventsOnly(TourEventsOnly tourEventsOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TourEventsOnlies.Add(tourEventsOnly);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TourEventsOnlyExists(tourEventsOnly.eventDay))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tourEventsOnly.eventDay }, tourEventsOnly);
        }

        // DELETE: api/TourEventsOnly/5
        [ResponseType(typeof(TourEventsOnly))]
        public async Task<IHttpActionResult> DeleteTourEventsOnly(int id)
        {
            TourEventsOnly tourEventsOnly = await db.TourEventsOnlies.FindAsync(id);
            if (tourEventsOnly == null)
            {
                return NotFound();
            }

            db.TourEventsOnlies.Remove(tourEventsOnly);
            await db.SaveChangesAsync();

            return Ok(tourEventsOnly);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourEventsOnlyExists(int id)
        {
            return db.TourEventsOnlies.Count(e => e.eventDay == id) > 0;
        }
    }
}