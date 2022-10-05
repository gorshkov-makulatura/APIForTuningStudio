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
    public class OrdersController : ApiController
    {
        private AutoTuneEntities db = new AutoTuneEntities();

        // GET: api/Orders
        [ResponseType(typeof(List<ResponseOrder>))]
        public IHttpActionResult GetOrders()
        {
            return Ok(db.Orders.ToList().ConvertAll(p => new ResponseOrder(p)));
        }
        [ResponseType(typeof(List<ResponseOrder>))]
        public IHttpActionResult GetOrders(int id)
        {
            var data = db.Orders.Where(x => x.ClientID == id).ToList().ConvertAll(p => new ResponseOrder(p));
            return Ok(data);
        }
        [ResponseType(typeof(List<ResponseOrder>))]
        public IHttpActionResult GetOrders(string Number)
        {
            var data = db.Orders.Where(x => x.Users2.PhoneNumber == Number).ToList().ConvertAll(p => new ResponseOrder(p));
            return Ok(data);
        }

        // GET: api/Orders/5

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrders(int id, Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders.ID)
            {
                return BadRequest();
            }

            db.Entry(orders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(Orders))]
        public IHttpActionResult PostOrders(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(orders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orders.ID }, orders);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Orders))]
        public IHttpActionResult DeleteOrders(int id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            db.Orders.Remove(orders);
            db.SaveChanges();

            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdersExists(int id)
        {
            return db.Orders.Count(e => e.ID == id) > 0;
        }
    }
}