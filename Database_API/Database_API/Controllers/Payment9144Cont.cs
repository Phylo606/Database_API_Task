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
    public class Payment9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public Payment9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Accountpayment9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment9144>>> GetAccountpayment9144()
        {
            return await _context.Payment9144.ToListAsync();
        }

        // GET: api/Accountpayment9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment9144>> GetAccountpayment9144(int id)
        {
            var accountpayment9144 = await _context.Payment9144.FindAsync(id);

            if (accountpayment9144 == null)
            {
                return NotFound();
            }

            return accountpayment9144;
        }

        // PUT: api/Accountpayment9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountpayment9144(int id, Payment9144 accountpayment9144)
        {
            if (id != accountpayment9144.ID)
            {
                return BadRequest();
            }

            _context.Entry(accountpayment9144).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Accountpayment9144Exists(id))
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

        // POST: api/Accountpayment9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Payment9144>> PostAccountpayment9144(Payment9144 ap)
        {
            //          _context.Accountpayment9144.Add(ap);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC MAKE_ACCOUNT_PAYMENT " +
                    "@PACCOUNTID = " + ap.ID +
                    ", @PAMOUNT = " + ap.Sum);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Accountpayment9144Exists(ap.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountpayment9144", new { id = ap.ID }, ap);
        }

        // DELETE: api/Accountpayment9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment9144>> DeleteAccountpayment9144(int id)
        {
            var accountpayment9144 = await _context.Payment9144.FindAsync(id);
            if (accountpayment9144 == null)
            {
                return NotFound();
            }

            _context.Payment9144.Remove(accountpayment9144);
            await _context.SaveChangesAsync();

            return accountpayment9144;
        }

        private bool Accountpayment9144Exists(int id)
        {
            return _context.Payment9144.Any(e => e.ID == id);
        }
    }
}
