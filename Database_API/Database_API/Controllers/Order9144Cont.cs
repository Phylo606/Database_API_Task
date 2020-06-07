using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database_API.Models;

namespace Database_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    class Order9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public Order9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Order9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order9144>>> GetOrder9144()
        {
            var openOrders = await Task.FromResult(_context.Order9144.FromSqlRaw("EXEC GET_OPEN_ORDERS").ToList());

            return openOrders;
        }

        // GET: api/Order9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order9144>> GetOrder9144(int id)
        {
            // var order9144 = await _context.Order9144.FindAsync(id);


            var orderID = await Task.FromResult(_context.Order9144.FromSqlRaw("EXEC GET_ORDER_BY_ID " +
                "@PORDERID = " + id).ToList());

            if (orderID == null)
            {
                return NotFound();
            }

            return orderID[0];
        }

        // PUT: api/Order9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder9144(int id, Order9144 o)
        {
            if (id != o.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(o).State = EntityState.Modified;

            try
            {

                _context.Order9144.FromSqlRaw("EXEC FULLFILL_ORDER " +
                    "@PORDERID = " + id +
                    ", @PACCOUNTID = " + o.Userid);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order9144Exists(id))
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

        // POST: api/Order9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order9144>> PostOrder9144(Order9144 o)
        {
            //  _context.Order9144.Add(o);

            var orderID = await Task.FromResult(_context.Order9144.FromSqlRaw("EXEC CREATE_ORDER " +
               "@PSHIPPINGADDRESS = " + o.Shippingaddress +
               ", @PUSERID = " + o.Userid).ToList());

            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetOrder9144", new { id = o.Orderid }, o);

            return orderID[0];
        }

        // DELETE: api/Order9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order9144>> DeleteOrder9144(int id)
        {
            var order9144 = await _context.Order9144.FindAsync(id);
            if (order9144 == null)
            {
                return NotFound();
            }

            _context.Order9144.Remove(order9144);
            await _context.SaveChangesAsync();

            return order9144;
        }

        private bool Order9144Exists(int id)
        {
            return _context.Order9144.Any(e => e.Orderid == id);
        }
    }
}
