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
    public class ProgressesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Progresses
        [ResponseType(typeof(List<ProgressModel>))]
        public IHttpActionResult GetProgressFromSelected(int id)
        {

            return Ok(db.Progress.Where(x=>x.id_selected==id).ToList().ConvertAll(x => new ProgressModel(x)));
        }

        // GET: api/Progresses/5
        [ResponseType(typeof(Progress))]
        public IHttpActionResult GetProgress(int id)
        {
            Progress progress = db.Progress.Find(id);
            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }

        // PUT: api/Progresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgress(int id, Progress progress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != progress.id_progress)
            {
                return BadRequest();
            }

            db.Entry(progress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressExists(id))
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

        // POST: api/Progresses
        [ResponseType(typeof(Progress))]
        public IHttpActionResult PostProgress(Progress progress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Progress.Add(progress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = progress.id_progress }, progress);
        }

        // DELETE: api/Progresses/5
        [ResponseType(typeof(Progress))]
        public IHttpActionResult DeleteProgress(int id)
        {
            Progress progress = db.Progress.Find(id);
            if (progress == null)
            {
                return NotFound();
            }

            db.Progress.Remove(progress);
            db.SaveChanges();

            return Ok(progress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgressExists(int id)
        {
            return db.Progress.Count(e => e.id_progress == id) > 0;
        }
    }
}