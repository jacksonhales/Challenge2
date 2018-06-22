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
using Challenge2.API.Scripts;

namespace Challenge2.API.Controllers
{
    public class TourEventsController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/TourEvents
        public IQueryable<TourEvent> GetTourEvents()
        {
            return db.TourEvents;
        }

        // GET: api/TourEvents/5
        [ResponseType(typeof(TourEvent))]
        public async Task<IHttpActionResult> GetTourEvent(int id)
        {
            TourEvent tourEvent = await db.TourEvents.FindAsync(id);
            if (tourEvent == null)
            {
                return NotFound();
            }

            return Ok(tourEvent);
        }

        // PUT: api/TourEvents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTourEvent(int id, TourEvent tourEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tourEvent.eventID)
            {
                return BadRequest();
            }

            db.Entry(tourEvent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourEventExists(id))
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

        // POST: api/TourEvents
        [ResponseType(typeof(TourEvent))]
        public async Task<IHttpActionResult> PostTourEvent(TourEvent tourEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TourEvents.Add(tourEvent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TourEventExists(tourEvent.eventID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tourEvent.eventID }, tourEvent);
        }

        // DELETE: api/TourEvents/5
        [ResponseType(typeof(TourEvent))]
        public async Task<IHttpActionResult> DeleteTourEvent(int id)
        {
            TourEvent tourEvent = await db.TourEvents.FindAsync(id);
            if (tourEvent == null)
            {
                return NotFound();
            }

            db.TourEvents.Remove(tourEvent);
            await db.SaveChangesAsync();

            return Ok(tourEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourEventExists(int id)
        {
            return db.TourEvents.Count(e => e.eventID == id) > 0;
        }
    }
}