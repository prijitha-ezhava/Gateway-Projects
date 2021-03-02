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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PassengersController : ApiController
    {
        private PassengersDBEntities db = new PassengersDBEntities();

        // GET: api/Passengers
        public IQueryable<Passengers> GetPassengers()
        {
            return db.Passengers;
        }

        // GET: api/Passengers/5
        [ResponseType(typeof(Passengers))]
        public IHttpActionResult GetPassengers(int id)
        {
            Passengers passengers = db.Passengers.Find(id);
            if (passengers == null)
            {
                return NotFound();
            }

            return Ok(passengers);
        }

        // PUT: api/Passengers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPassengers(int id, Passengers passengers)
        {
           
            if (id != passengers.ID)
            {
                return BadRequest();
            }

            db.Entry(passengers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengersExists(id))
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

        // POST: api/Passengers
        [ResponseType(typeof(Passengers))]
        public IHttpActionResult PostPassengers(Passengers passengers)
        {
           

            db.Passengers.Add(passengers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = passengers.ID }, passengers);
        }

        // DELETE: api/Passengers/5
        [ResponseType(typeof(Passengers))]
        public IHttpActionResult DeletePassengers(int id)
        {
            Passengers passengers = db.Passengers.Find(id);
            if (passengers == null)
            {
                return NotFound();
            }

            db.Passengers.Remove(passengers);
            db.SaveChanges();

            return Ok(passengers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassengersExists(int id)
        {
            return db.Passengers.Count(e => e.ID == id) > 0;
        }
    }
}