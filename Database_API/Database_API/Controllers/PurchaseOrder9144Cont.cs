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
    public class PurchaseOrder9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public PurchaseOrder9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Purchaseorder9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder9144>>> GetPurchaseorder9144()
        {
            return await _context.PurchaseOrder9144.ToListAsync();
        }

        // GET: api/Purchaseorder9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrder9144>> GetPurchaseorder9144(int id)
        {
            var purchaseorder9144 = await _context.PurchaseOrder9144.FindAsync(id);

            if (purchaseorder9144 == null)
            {
                return NotFound();
            }

            return purchaseorder9144;
        }

        // PUT: api/Purchaseorder9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseorder9144(int id, PurchaseOrder9144 purchaseorder9144)
        {
            if (id != purchaseorder9144.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(purchaseorder9144).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Purchaseorder9144Exists(id))
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

        // POST: api/Purchaseorder9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PurchaseOrder9144>> PostPurchaseorder9144(PurchaseOrder9144 p)
        {
            // _context.Purchaseorder9144.Add(purchaseorder9144);
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC PURCHASE_STOCK " +
                    "@PPRODID = " + p.ProductID +
                    ", @PLOCID = " + p.LocationID +
                    ", @PQTY = " + p.Amount);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Purchaseorder9144Exists(p.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPurchaseorder9144", new { id = p.ProductID }, p);
        }

        // DELETE: api/Purchaseorder9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseOrder9144>> DeletePurchaseorder9144(int id)
        {
            var purchaseorder9144 = await _context.PurchaseOrder9144.FindAsync(id);
            if (purchaseorder9144 == null)
            {
                return NotFound();
            }

            _context.PurchaseOrder9144.Remove(purchaseorder9144);
            await _context.SaveChangesAsync();

            return purchaseorder9144;
        }

        private bool Purchaseorder9144Exists(int id)
        {
            return _context.PurchaseOrder9144.Any(e => e.ProductID == id);
        }
    }
}
