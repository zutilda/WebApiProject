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
    public class UsersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Users
        [ResponseType(typeof(List<UsersModel>))]
        public IHttpActionResult GetUsers()
        {

            return Ok(db.Users.ToList().ConvertAll(x => new UsersModel(x)));
        }



        // GET: api/UserLogins
        
        public bool GetLogins(string loginUser,string pass)
        {
            loginUser = loginUser.Replace("{","");
            loginUser = loginUser.Replace("}", "");
            pass = pass.Replace("{", "");
            pass = pass.Replace("}", "");
            int countUser = db.Users.ToList().Where(x => x.login == loginUser && PasswordShifr.DeShifr(x.password) == pass).ToArray().Length;
            return countUser == 1;
        }



        // GET: api/UserLoginsAllInform

        public UsersModel GetLoginsAllInform(string password, string loginUser)
        {
           
            loginUser = loginUser.Replace("{", "");
            loginUser = loginUser.Replace("}", "");
            password = password.Replace("{", "");
            password = password.Replace("}", "");
            return new UsersModel(db.Users.ToList().FirstOrDefault(x => x.login == loginUser && PasswordShifr.DeShifr(x.password) == password));
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
            if (db.Users.First(x => x.login == users.login) != null)
            {
                return BadRequest();
            }
            if (id != users.id_user)
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
        public IHttpActionResult PostUsers(Users users,string pass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pass = pass.Replace("{", "");
            pass = pass.Replace("}", "");

            users.password = PasswordShifr.Shifr(pass);
           
            db.Users.Add(users);
           
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.id_user }, users);
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
            return db.Users.Count(e => e.id_user == id) > 0;
        }
    }
}