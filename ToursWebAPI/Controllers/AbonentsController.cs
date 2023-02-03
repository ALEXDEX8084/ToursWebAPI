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
using ToursWebAPI;
using ToursWebAPI.Entities;

namespace ToursWebAPI.Controllers
{
    public class AbonentsController : ApiController
    {
        private cellularproviderEntities db = new cellularproviderEntities();

        // GET: api/Abonents
        public IQueryable<Abonent> GetAbonents()
        {
            return db.Abonents;
        }

        // GET: api/Abonents/5
        [ResponseType(typeof(Abonent))]
        public IHttpActionResult GetAbonent(int id)
        {
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return NotFound();
            }

            return Ok(abonent);
        }

        // PUT: api/Abonents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbonent(int id, Abonent abonent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonent.IDAbonent)
            {
                return BadRequest();
            }

            db.Entry(abonent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonentExists(id))
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

        // POST: api/Abonents
        [ResponseType(typeof(Abonent))]
        public IHttpActionResult PostAbonent(Abonent abonent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abonents.Add(abonent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = abonent.IDAbonent }, abonent);
        }

        // DELETE: api/Abonents/5
        [ResponseType(typeof(Abonent))]
        public IHttpActionResult DeleteAbonent(int id)
        {
            Abonent abonent = db.Abonents.Find(id);
            if (abonent == null)
            {
                return NotFound();
            }

            db.Abonents.Remove(abonent);
            db.SaveChanges();

            return Ok(abonent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbonentExists(int id)
        {
            return db.Abonents.Count(e => e.IDAbonent == id) > 0;
        }
    }
}