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
    public class SelectedsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Selecteds
        [ResponseType(typeof(List<SelectedModel>))]
        public IHttpActionResult GetSelectedFromUserID(int idUser)
        {

            return Ok(db.Selected.Where(x=> x.id_users== idUser).ToList().ConvertAll(x => new SelectedModel(x)));
        }

        // GET: api/Selecteds/5
        [ResponseType(typeof(Selected))]
        public IHttpActionResult GetSelected(int idSelected)
        {
            Selected selected = db.Selected.Find(idSelected);
            if (selected == null)
            {
                return NotFound();
            }

            return Ok(selected);
        }

        // GET: api/Selecteds/5

        public string GetSelectedCount(int id)
        {
            return "Колличество избраных хоби "+ db.Selected.Where(x => x.id_users == id).ToList().Count+"\nВсего хоби заложеных в программе "+ db.Hobby.ToList().Count;
        }

        // PUT: api/Selecteds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSelected(int id, Selected selected)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selected.id_selected)
            {
                return BadRequest();
            }

            db.Entry(selected).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelectedExists(id))
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

        // POST: api/Selecteds
        [ResponseType(typeof(Selected))]
        public IHttpActionResult PostSelected(Selected selected)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            db.Selected.Add(selected);
            
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = selected.id_selected }, selected);
        }

        // DELETE: api/Selecteds/5
        [ResponseType(typeof(Selected))]
        public IHttpActionResult DeleteSelected(int id)
        {
            Selected selected = db.Selected.Find(id);
            if (selected == null)
            {
                return NotFound();
            }

            db.Selected.Remove(selected);
            db.SaveChanges();

            return Ok(selected);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SelectedExists(int id)
        {
            return db.Selected.Count(e => e.id_selected == id) > 0;
        }
    }
}