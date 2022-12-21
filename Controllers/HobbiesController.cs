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
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class HobbiesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Hobbies
        [ResponseType(typeof(HobbyModel))]
        public IHttpActionResult GetHobby()
        {
            Random random= new Random();
            return Ok(new HobbyModel(db.Hobby.ToList()[random.Next(0, db.Hobby.ToList().Count)]));
        }

        // GET: api/Hobbies/5
        [ResponseType(typeof(Hobby))]
        public IHttpActionResult GetHobby(int id)
        {
            Hobby hobby = db.Hobby.Find(id);
            if (hobby == null)
            {
                return NotFound();
            }

            return Ok(hobby);
        }

        // PUT: api/Hobbies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHobby(int id, Hobby hobby)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hobby.hobby_id)
            {
                return BadRequest();
            }

            db.Entry(hobby).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HobbyExists(id))
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

        // POST: api/Hobbies
        [ResponseType(typeof(Hobby))]
        public IHttpActionResult PostHobby(Hobby hobby)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hobby.Add(hobby);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hobby.hobby_id }, hobby);
        }

        // DELETE: api/Hobbies/5
        [ResponseType(typeof(Hobby))]
        public IHttpActionResult DeleteHobby(int id)
        {
            Hobby hobby = db.Hobby.Find(id);
            if (hobby == null)
            {
                return NotFound();
            }

            db.Hobby.Remove(hobby);
            db.SaveChanges();

            return Ok(hobby);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HobbyExists(int id)
        {
            return db.Hobby.Count(e => e.hobby_id == id) > 0;
        }
    }
}