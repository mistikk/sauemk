﻿using System;
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
        public async Task<IHttpActionResult> GetEtkinlik(int id)
        {
            Etkinlik etkinlik = await db.Etkinlik.FindAsync(id);
            if (etkinlik == null)
            {
                return NotFound();
            }

            return Ok(etkinlik);
        }

        // GET: api/GecmisEtkinlik
        [Route("api/GecmisEtkinlik")]
        [HttpGet]
        [ResponseType(typeof(Etkinlik))]
        public IHttpActionResult GecmisEtkinlik()
        {
            IQueryable<Etkinlik> etkinlik = db.Etkinlik.Where(x =>x.Tarihi < DateTime.Now).OrderBy(x => x.Tarihi).Take(4);
            if (etkinlik == null)
            {
                return NotFound();
            }

            return Ok(etkinlik);
        }

        // GET: api/GelecekEtkinlik
        [Route("api/GelecekEtkinlik")]
        [HttpGet]
        [ResponseType(typeof(Etkinlik))]
        public IHttpActionResult GelecekEtkinlik()
        {
            IQueryable<Etkinlik> etkinlik = db.Etkinlik.Where(x => x.Tarihi > DateTime.Now.AddDays(7)).OrderByDescending(x => x.Tarihi).Take(4);
            if (etkinlik == null)
            {
                return NotFound();
            }

            return Ok(etkinlik);
        }

        // GET: api/HaftaEtkinlik
        [Route("api/HaftaEtkinlik")]
        [HttpGet]
        [ResponseType(typeof(Etkinlik))]
        public IHttpActionResult HaftaEtkinlik()
        {
            IQueryable<Etkinlik> etkinlik = db.Etkinlik.Where(x => x.Tarihi < DateTime.Now.AddDays(7) && x.Tarihi > DateTime.Now).OrderByDescending(x => x.Tarihi).Take(4);
            if (etkinlik == null)
            {
                return NotFound();
            }

            return Ok(etkinlik);
        }


        // PUT: api/Etkinliks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEtkinlik(int id, Etkinlik etkinlik)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostEtkinlik(Etkinlik etkinlik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etkinlik.Add(etkinlik);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = etkinlik.Id }, etkinlik);
        }

        // DELETE: api/Etkinliks/5
        [ResponseType(typeof(Etkinlik))]
        public async Task<IHttpActionResult> DeleteEtkinlik(int id)
        {
            Etkinlik etkinlik = await db.Etkinlik.FindAsync(id);
            if (etkinlik == null)
            {
                return NotFound();
            }

            db.Etkinlik.Remove(etkinlik);
            await db.SaveChangesAsync();

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

        private bool EtkinlikExists(int id)
        {
            return db.Etkinlik.Count(e => e.Id == id) > 0;
        }
    }
}