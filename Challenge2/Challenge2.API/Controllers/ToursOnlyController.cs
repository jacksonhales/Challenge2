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
    public class ToursOnlyController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/ToursOnly
        public IQueryable<ToursOnly> GetToursOnlies()
        {
            return db.ToursOnlies;
        }

        // GET: api/ToursOnly/5
        [ResponseType(typeof(ToursOnly))]
        public async Task<IHttpActionResult> GetToursOnly(int id)
        {
            ToursOnly toursOnly = await db.ToursOnlies.FirstOrDefaultAsync(t => t.tourID == id);
            if (toursOnly == null)
            {
                return NotFound();
            }

            return Ok(toursOnly);
        }

        // PUT: api/ToursOnly/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutToursOnly(int id, ToursOnly toursOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toursOnly.tourID)
            {
                return BadRequest();
            }

            db.Entry(toursOnly).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToursOnlyExists(id))
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

        // POST: api/ToursOnly
        [ResponseType(typeof(ToursOnly))]
        public async Task<IHttpActionResult> PostToursOnly(ToursOnly toursOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToursOnlies.Add(toursOnly);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToursOnlyExists(toursOnly.tourID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = toursOnly.tourID }, toursOnly);
        }

        // DELETE: api/ToursOnly/5
        [ResponseType(typeof(ToursOnly))]
        public async Task<IHttpActionResult> DeleteToursOnly(int id)
        {
            ToursOnly toursOnly = await db.ToursOnlies.FindAsync(id);
            if (toursOnly == null)
            {
                return NotFound();
            }

            db.ToursOnlies.Remove(toursOnly);
            await db.SaveChangesAsync();

            return Ok(toursOnly);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToursOnlyExists(int id)
        {
            return db.ToursOnlies.Count(e => e.tourID == id) > 0;
        }
    }
}