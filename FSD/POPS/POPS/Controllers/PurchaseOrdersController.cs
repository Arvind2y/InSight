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
using POPS.DAL.Models;

namespace POPS.Controllers
{
    public class PurchaseOrdersController : ApiController
    {
        private POPSDbContext db = new POPSDbContext();

        // GET: api/PurchaseOrders
        public IQueryable<POMaster> GetPOMasters()
        {
            return db.POMasters.Include(s => s.Supplier);
        }

        // GET: api/PurchaseOrders/5
        [ResponseType(typeof(POMaster))]
        public IHttpActionResult GetPOMaster(int id)
        {
            POMaster pOMaster = db.POMasters.Find(id);
            if (pOMaster == null)
            {
                return NotFound();
            }

            return Ok(pOMaster);
        }

        // PUT: api/PurchaseOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPOMaster(int id, POMaster pOMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pOMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(pOMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POMasterExists(id))
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

        // POST: api/PurchaseOrders
        [ResponseType(typeof(POMaster))]
        public IHttpActionResult PostPOMaster(POMaster pOMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.POMasters.Add(pOMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pOMaster.Id }, pOMaster);
        }

        // DELETE: api/PurchaseOrders/5
        [ResponseType(typeof(POMaster))]
        public IHttpActionResult DeletePOMaster(int id)
        {
            POMaster pOMaster = db.POMasters.Find(id);
            if (pOMaster == null)
            {
                return NotFound();
            }

            db.POMasters.Remove(pOMaster);
            db.SaveChanges();

            return Ok(pOMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool POMasterExists(int id)
        {
            return db.POMasters.Count(e => e.Id == id) > 0;
        }
    }
}