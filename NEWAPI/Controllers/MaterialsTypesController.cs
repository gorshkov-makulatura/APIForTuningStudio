using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using NEWAPI.Entities;
using NEWAPI.Models;

namespace NEWAPI.Controllers
{
    public class MaterialsTypesController : ApiController
    {
        private AutoTuneEntities db = new AutoTuneEntities();

        [ResponseType(typeof(List<ResponceMaterialType>))]
        public IHttpActionResult GetMaterialsType()
        {
            return Ok(db.MaterialsType.ToList().ConvertAll(p => new ResponceMaterialType(p)));
        }

        // GET: api/MaterialsTypes/5
        [ResponseType(typeof(MaterialsType))]
        public IHttpActionResult GetMaterialsType(int id)
        {
            MaterialsType materialsType = db.MaterialsType.Find(id);
            if (materialsType == null)
            {
                return NotFound();
            }

            return Ok(materialsType);
        }

        // PUT: api/MaterialsTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterialsType(int id, MaterialsType materialsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materialsType.ID)
            {
                return BadRequest();
            }

            db.Entry(materialsType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialsTypeExists(id))
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

        // POST: api/MaterialsTypes
        [ResponseType(typeof(MaterialsType))]
        public IHttpActionResult PostMaterialsType(MaterialsType materialsType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaterialsType.Add(materialsType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materialsType.ID }, materialsType);
        }

        // DELETE: api/MaterialsTypes/5
        [ResponseType(typeof(MaterialsType))]
        public IHttpActionResult DeleteMaterialsType(int id)
        {
            MaterialsType materialsType = db.MaterialsType.Find(id);
            if (materialsType == null)
            {
                return NotFound();
            }

            db.MaterialsType.Remove(materialsType);
            db.SaveChanges();

            return Ok(materialsType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialsTypeExists(int id)
        {
            return db.MaterialsType.Count(e => e.ID == id) > 0;
        }
    }
}