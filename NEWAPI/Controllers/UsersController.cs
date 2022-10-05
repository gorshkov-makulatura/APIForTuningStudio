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
using AutoTuneAPI.Models;
using NEWAPI.Entities;

namespace NEWAPI.Controllers
{
    public class UsersController : ApiController
    {
        private AutoTuneEntities db = new AutoTuneEntities();

        // GET: api/Users
        [ResponseType(typeof(List<ResponseUser>))]
            public IHttpActionResult GetUsers()
            {
                return Ok(db.Users.ToList().ConvertAll(p => new ResponseUser(p)));
            }
        public IHttpActionResult GetUsers(string email, string password)
        {
            var data = db.Users.SingleOrDefault(p => p.Email == email && p.Password == password && p.IsActive == true);
            if (data == null)
            {
                return Ok(false);
            }
            return Ok(true);

        }
        [ResponseType(typeof(ResponseUser))]
        public IHttpActionResult GetUsers(string email)
        {
            var data = new ResponseUser(db.Users.SingleOrDefault(p => p.Email == email));
            return Ok(data);
        }
        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.ID)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.ID }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.ID == id) > 0;
        }
    }
}