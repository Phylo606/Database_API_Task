using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_API.Models;
using System.Data.SqlClient;

namespace Database_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class Location9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public Location9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Location9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location9144>>> GetLocation9144()
        {
            return await _context.Location9144.ToListAsync();
        }

        // GET: api/Location9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location9144>> GetLocation9144(string id)
        {
            var location = await Task.FromResult(_context.Location9144.FromSqlRaw("EXEC GET_LOCATION_BY_ID " +
                "@PLOCID = " + id).ToList());


            if (location == null)
            {
                return NotFound();
            }

            // return Task.FromResult<Location9144>(new List<Location9144>() { location });
            return location[0];
        }

        // PUT: api/Location9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation9144(string id, Location9144 l)
        {
            if (id != l.LocationID)
            {
                return BadRequest();
            }

            // _context.Entry(location9144).State = EntityState.Modified;

            try
            {



                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Location9144Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Location9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Location9144>> PostLocation9144(Location9144 l)
        {
            // _context.Location9144.Add(location9144);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC ADD_LOCATION @PLOCID = " + l.LocationID +
                    ", @PLOCNAME = " + l.LocationName +
                    ", @PLOCADDRESS = " + l.Address +
                    ", @PMANAGER = " + l.Manager);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Location9144Exists(l.LocationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocation9144", new { id = l.LocationID }, l);
        }

        // DELETE: api/Location9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Location9144>> DeleteLocation9144(string id)
        {
            var location9144 = await _context.Location9144.FindAsync(id);
            if (location9144 == null)
            {
                return NotFound();
            }

            _context.Location9144.Remove(location9144);
            await _context.SaveChangesAsync();

            return location9144;
        }

        private bool Location9144Exists(string id)
        {
            return _context.Location9144.Any(e => e.LocationID == id);
        }
    }
}
