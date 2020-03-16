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

namespace WebApiDemo.Models
{
    public class WebApIEmpsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/WebApIEmps
        public IQueryable<WebApIEmp> GetWebApIEmps()
        {
            return db.WebApIEmps;
        }

        // GET: api/WebApIEmps/5
        [ResponseType(typeof(WebApIEmp))]
        public IHttpActionResult GetWebApIEmp(int id)
        {
            WebApIEmp webApIEmp = db.WebApIEmps.Find(id);
            if (webApIEmp == null)
            {
                return NotFound();
            }

            return Ok(webApIEmp);
        }

        // PUT: api/WebApIEmps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWebApIEmp(int id, WebApIEmp webApIEmp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != webApIEmp.Id)
            {
                return BadRequest();
            }

            db.Entry(webApIEmp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebApIEmpExists(id))
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

        // POST: api/WebApIEmps
        [ResponseType(typeof(WebApIEmp))]
        public IHttpActionResult PostWebApIEmp(WebApIEmp webApIEmp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WebApIEmps.Add(webApIEmp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = webApIEmp.Id }, webApIEmp);
        }

        // DELETE: api/WebApIEmps/5
        [ResponseType(typeof(WebApIEmp))]
        public IHttpActionResult DeleteWebApIEmp(int id)
        {
            WebApIEmp webApIEmp = db.WebApIEmps.Find(id);
            if (webApIEmp == null)
            {
                return NotFound();
            }

            db.WebApIEmps.Remove(webApIEmp);
            db.SaveChanges();

            return Ok(webApIEmp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebApIEmpExists(int id)
        {
            return db.WebApIEmps.Count(e => e.Id == id) > 0;
        }
    }
}