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
using sauemk.Models;

namespace sauemk.Controllers
{
    public class EtkinliksController : ApiController
    {
        private sauemkEntities db = new sauemkEntities();

        // GET: api/Etkinliks
        public IQueryable<Etkinlik> GetEtkinlik()
        {
            return db.Etkinlik;
        }

        // GET: api/Etkinliks/5
        [ResponseType(typeof(Etkinlik))]
        public IHttpActionResult GetEtkinlik(string id)
        {
            Etkinlik etkinlik = db.Etkinlik.Find(id);
            if (etkinlik == null)
            {
                return NotFound();
            }

            return Ok(etkinlik);
        }

        // PUT: api/Etkinliks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEtkinlik(string id, Etkinlik etkinlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etkinlik.Id)
            {
                return BadRequest();
            }

            db.Entry(etkinlik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtkinlikExists(id))
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

        // POST: api/Etkinliks
        [ResponseType(typeof(Etkinlik))]
        public IHttpActionResult PostEtkinlik(Etkinlik etkinlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etkinlik.Add(etkinlik);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EtkinlikExists(etkinlik.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = etkinlik.Id }, etkinlik);
        }

        // DELETE: api/Etkinliks/5
        [ResponseType(typeof(Etkinlik))]
        public IHttpActionResult DeleteEtkinlik(string id)
        {
            Etkinlik etkinlik = db.Etkinlik.Find(id);
            if (etkinlik == null)
            {
                return NotFound();
            }

            db.Etkinlik.Remove(etkinlik);
            db.SaveChanges();

            return Ok(etkinlik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtkinlikExists(string id)
        {
            return db.Etkinlik.Count(e => e.Id == id) > 0;
        }
    }
}