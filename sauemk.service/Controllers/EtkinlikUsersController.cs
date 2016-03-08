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
using sauemk.Models;

namespace sauemk.Controllers
{
    public class EtkinlikUsersController : ApiController
    {
        private EmkEntities db = new EmkEntities();

        // GET: api/EtkinlikUsers
        public IQueryable<EtkinlikUser> GetEtkinlikUser()
        {
            return db.EtkinlikUser;
        }

        // GET: api/EtkinlikUsers/5
        [ResponseType(typeof(EtkinlikUser))]
        public async Task<IHttpActionResult> GetEtkinlikUser(int id)
        {
            EtkinlikUser etkinlikUser = await db.EtkinlikUser.FindAsync(id);
            if (etkinlikUser == null)
            {
                return NotFound();
            }

            return Ok(etkinlikUser);
        }

        // PUT: api/EtkinlikUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEtkinlikUser(int id, EtkinlikUser etkinlikUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etkinlikUser.Id)
            {
                return BadRequest();
            }

            db.Entry(etkinlikUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtkinlikUserExists(id))
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

        // POST: api/EtkinlikUsers
        [ResponseType(typeof(EtkinlikUser))]
        public async Task<IHttpActionResult> PostEtkinlikUser(EtkinlikUser etkinlikUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!UserExists(etkinlikUser.UserId, etkinlikUser.EtkinlikId))
            {
                db.EtkinlikUser.Add(etkinlikUser);

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (EtkinlikUserExists(etkinlikUser.Id))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            

            return CreatedAtRoute("DefaultApi", new { id = etkinlikUser.Id }, etkinlikUser);
        }

        // DELETE: api/EtkinlikUsers/5
        [ResponseType(typeof(EtkinlikUser))]
        public async Task<IHttpActionResult> DeleteEtkinlikUser(int id)
        {
            EtkinlikUser etkinlikUser = await db.EtkinlikUser.FindAsync(id);
            if (etkinlikUser == null)
            {
                return NotFound();
            }

            db.EtkinlikUser.Remove(etkinlikUser);
            await db.SaveChangesAsync();

            return Ok(etkinlikUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private bool UserExists(string username, string etkinlikId)
        {
            return db.EtkinlikUser.Count(e => e.UserId == username && e.EtkinlikId == etkinlikId) > 0;
        }
        private bool EtkinlikExists(string etkinlikId)
        {
            return db.EtkinlikUser.Count(e => e.EtkinlikId == etkinlikId) > 0;
        }
        private bool EtkinlikUserExists(int id)
        {
            return db.EtkinlikUser.Count(e => e.Id == id) > 0;
        }
    }
}