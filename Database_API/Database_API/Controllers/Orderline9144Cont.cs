using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Database_API.Models;

namespace Database_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class Orderline9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public Orderline9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Orderline9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orderline9144>>> GetOrderline9144()
        {
            return await _context.Orderline9144.ToListAsync();
        }

        // GET: api/Orderline9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orderline9144>> GetOrderline9144(int id)
        {
            var orderline9144 = await _context.Orderline9144.FindAsync(id);

            if (orderline9144 == null)
            {
                return NotFound();
            }

            return orderline9144;
        }

        // PUT: api/Orderline9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderline9144(int id, Orderline9144 orderline9144)
        {
            if (id != orderline9144.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(orderline9144).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Orderline9144Exists(id))
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

        // POST: api/Orderline9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Orderline9144>> PostOrderline9144(Orderline9144 ol)
        {
            // _context.Orderline9144.Add(ol);
            try
            {

                _context.Orderline9144.FromSqlRaw("EXEC ADD_PRODUCT_TO_ORDER @PORDERID = " + ol.Orderid + 
                    ", @PPRODIID = " + ol.Productid +
                    ", @PQTY = " + ol.Quantity +
                    ", @DISCOUNT = " + ol.Discount);
                 await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Orderline9144Exists(ol.Orderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderline9144", new { id = ol.Orderid }, ol);
        }

        // DELETE: api/Orderline9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Orderline9144>> DeleteOrderline9144(int id, int prodid)
        {
            // var orderline9144 = await _context.Orderline9144.FindAsync(id);

            var order = await Task.FromResult(_context.Orderline9144.FromSqlRaw("EXEC REMOVE_PRODUCT_FROM_ORDER " +
                "@PORDERID = " + id + ", @PPRODID = " + prodid).ToList());
            if (order == null)
            {
                return NotFound();
            }

            // _context.Orderline9144.Remove(orderline9144);
            await _context.SaveChangesAsync();

            return order[0];
        }

        private bool Orderline9144Exists(int id)
        {
            return _context.Orderline9144.Any(e => e.Orderid == id);
        }
    }
}
