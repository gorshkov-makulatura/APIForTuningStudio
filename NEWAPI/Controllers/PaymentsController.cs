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
using NEWAPI.Entities;
using NEWAPI.Models;

namespace NEWAPI.Controllers
{
    public class PaymentsController : ApiController
    {
        private AutoTuneEntities db = new AutoTuneEntities();

        [ResponseType(typeof(List<ResponcePayment>))]
        public IHttpActionResult GetOrders()
        {
            return Ok(db.Payments.ToList().ConvertAll(p => new ResponcePayment(p)));
        }

        [ResponseType(typeof(Payments))]
        public IHttpActionResult GetPayments(int id)
        {
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return NotFound();
            }

            return Ok(payments);
        }

        // PUT: api/Payments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPayments(int id, Payments payments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payments.ID)
            {
                return BadRequest();
            }

            db.Entry(payments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsExists(id))
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

        // POST: api/Payments
        [ResponseType(typeof(Payments))]
        public IHttpActionResult PostPayments(Payments payments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payments.Add(payments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payments.ID }, payments);
        }

        // DELETE: api/Payments/5
        [ResponseType(typeof(Payments))]
        public IHttpActionResult DeletePayments(int id)
        {
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payments);
            db.SaveChanges();

            return Ok(payments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentsExists(int id)
        {
            return db.Payments.Count(e => e.ID == id) > 0;
        }
    }
}