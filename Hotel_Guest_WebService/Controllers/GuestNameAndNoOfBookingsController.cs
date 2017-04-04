using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Hotel_Guest_WebService;

namespace Hotel_Guest_WebService.Controllers
{
    public class GuestNameAndNoOfBookingsController : ApiController
    {
        private GuestBookingViewContext db = new GuestBookingViewContext();

        // GET: api/GuestNameAndNoOfBookings
        public IQueryable<GuestNameAndNoOfBookings> GetGuestNameAndNoOfBookings()
        {
            return db.GuestNameAndNoOfBookings;
        }

        // GET: api/GuestNameAndNoOfBookings/5
        [ResponseType(typeof(GuestNameAndNoOfBookings))]
        public async Task<IHttpActionResult> GetGuestNameAndNoOfBookings(string id)
        {
            GuestNameAndNoOfBookings guestNameAndNoOfBookings = await db.GuestNameAndNoOfBookings.FindAsync(id);
            if (guestNameAndNoOfBookings == null)
            {
                return NotFound();
            }

            return Ok(guestNameAndNoOfBookings);
        }

        // PUT: api/GuestNameAndNoOfBookings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGuestNameAndNoOfBookings(string id, GuestNameAndNoOfBookings guestNameAndNoOfBookings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestNameAndNoOfBookings.Name)
            {
                return BadRequest();
            }

            db.Entry(guestNameAndNoOfBookings).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestNameAndNoOfBookingsExists(id))
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

        // POST: api/GuestNameAndNoOfBookings
        [ResponseType(typeof(GuestNameAndNoOfBookings))]
        public async Task<IHttpActionResult> PostGuestNameAndNoOfBookings(GuestNameAndNoOfBookings guestNameAndNoOfBookings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GuestNameAndNoOfBookings.Add(guestNameAndNoOfBookings);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GuestNameAndNoOfBookingsExists(guestNameAndNoOfBookings.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guestNameAndNoOfBookings.Name }, guestNameAndNoOfBookings);
        }

        // DELETE: api/GuestNameAndNoOfBookings/5
        [ResponseType(typeof(GuestNameAndNoOfBookings))]
        public async Task<IHttpActionResult> DeleteGuestNameAndNoOfBookings(string id)
        {
            GuestNameAndNoOfBookings guestNameAndNoOfBookings = await db.GuestNameAndNoOfBookings.FindAsync(id);
            if (guestNameAndNoOfBookings == null)
            {
                return NotFound();
            }

            db.GuestNameAndNoOfBookings.Remove(guestNameAndNoOfBookings);
            await db.SaveChangesAsync();

            return Ok(guestNameAndNoOfBookings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestNameAndNoOfBookingsExists(string id)
        {
            return db.GuestNameAndNoOfBookings.Count(e => e.Name == id) > 0;
        }
    }
}