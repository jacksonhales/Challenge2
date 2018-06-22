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
    public class ClientsOnlyController : ApiController
    {
        private Challenge2Entities db = new Challenge2Entities();

        // GET: api/ClientsOnly
        public IQueryable<ClientsOnly> GetClientsOnlies()
        {
            return db.ClientsOnlies;
        }

        // GET: api/ClientsOnly/5
        [ResponseType(typeof(ClientsOnly))]
        public async Task<IHttpActionResult> GetClientsOnly(int id)
        {
            ClientsOnly clientsOnly = await db.ClientsOnlies.FirstOrDefaultAsync(c => c.clientID == id); ;
            if (clientsOnly == null)
            {
                return NotFound();
            }

            return Ok(clientsOnly);
        }

        // PUT: api/ClientsOnly/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientsOnly(int id, ClientsOnly clientsOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientsOnly.clientID)
            {
                return BadRequest();
            }

            db.Entry(clientsOnly).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsOnlyExists(id))
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

        // POST: api/ClientsOnly
        [ResponseType(typeof(ClientsOnly))]
        public async Task<IHttpActionResult> PostClientsOnly(ClientsOnly clientsOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientsOnlies.Add(clientsOnly);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientsOnlyExists(clientsOnly.clientID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clientsOnly.clientID }, clientsOnly);
        }

        // DELETE: api/ClientsOnly/5
        [ResponseType(typeof(ClientsOnly))]
        public async Task<IHttpActionResult> DeleteClientsOnly(int id)
        {
            ClientsOnly clientsOnly = await db.ClientsOnlies.FindAsync(id);
            if (clientsOnly == null)
            {
                return NotFound();
            }

            db.ClientsOnlies.Remove(clientsOnly);
            await db.SaveChangesAsync();

            return Ok(clientsOnly);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsOnlyExists(int id)
        {
            return db.ClientsOnlies.Count(e => e.clientID == id) > 0;
        }
    }
}