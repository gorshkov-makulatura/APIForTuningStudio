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
    public class TypeOfServicesController : ApiController
    {
        private AutoTuneEntities db = new AutoTuneEntities();


        // GET: api/TypeOfServices/5
        [ResponseType(typeof(List<ResponceServices>))]
        public IHttpActionResult GetTypeOfServices()
        {
            return Ok(db.TypeOfServices.ToList().ConvertAll(p => new ResponceServices(p)));
        }

        // PUT: api/TypeOfServices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeOfServices(int id, TypeOfServices typeOfServices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeOfServices.ID)
            {
                return BadRequest();
            }

            db.Entry(typeOfServices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfServicesExists(id))
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

        // POST: api/TypeOfServices
        [ResponseType(typeof(TypeOfServices))]
        public IHttpActionResult PostTypeOfServices(TypeOfServices typeOfServices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeOfServices.Add(typeOfServices);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeOfServices.ID }, typeOfServices);
        }

        // DELETE: api/TypeOfServices/5
        [ResponseType(typeof(TypeOfServices))]
        public IHttpActionResult DeleteTypeOfServices(int id)
        {
            TypeOfServices typeOfServices = db.TypeOfServices.Find(id);
            if (typeOfServices == null)
            {
                return NotFound();
            }

            db.TypeOfServices.Remove(typeOfServices);
            db.SaveChanges();

            return Ok(typeOfServices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeOfServicesExists(int id)
        {
            return db.TypeOfServices.Count(e => e.ID == id) > 0;
        }
    }
}