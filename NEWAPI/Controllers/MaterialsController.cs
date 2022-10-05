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
    public class MaterialsController : ApiController
    {
        private AutoTuneEntities db = new AutoTuneEntities();

        // GET: api/Materials
        [ResponseType(typeof(List<ResponceMaterial>))]
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Materials.Where(x=>x.StockStatus == true).ToList().ConvertAll(p => new ResponceMaterial(p)));
        }

        // GET: api/Materials/5
        [ResponseType(typeof(Materials))]


        public IHttpActionResult GetMaterials(int id)
        {
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return NotFound();
            }

            return Ok(materials);
        }

        // PUT: api/Materials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterials(int id, Materials materials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materials.ID)
            {
                return BadRequest();
            }

            db.Entry(materials).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialsExists(id))
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

        // POST: api/Materials
        [ResponseType(typeof(Materials))]
        public IHttpActionResult PostMaterials(Materials materials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(materials);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materials.ID }, materials);
        }

        // DELETE: api/Materials/5
        [ResponseType(typeof(Materials))]
        public IHttpActionResult DeleteMaterials(int id)
        {
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return NotFound();
            }

            db.Materials.Remove(materials);
            db.SaveChanges();

            return Ok(materials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialsExists(int id)
        {
            return db.Materials.Count(e => e.ID == id) > 0;
        }
    }
}