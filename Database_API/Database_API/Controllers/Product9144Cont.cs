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
    class Product9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public Product9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Product9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product9144>>> GetProduct9144()
        {
            return await _context.Product9144.ToListAsync();
        }

        // GET: api/Product9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product9144>> GetProduct9144(int id)
        {
            // var product9144 = await _context.Product9144.FindAsync(id);

            var product = await Task.FromResult(_context.Product9144.FromSqlRaw("EXEC GET_PRODUCT_BY_ID " +
                "@PPRODID = " + id).ToList());

            if (product == null)
            {
                return NotFound();
            }

            return product[0];
        }

        // PUT: api/Product9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct9144(int id, Product9144 product9144)
        {
            if (id != product9144.Productid)
            {
                return BadRequest();
            }

            _context.Entry(product9144).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product9144Exists(id))
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

        // POST: api/Product9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product9144>> PostProduct9144(Product9144 p)
        {
            // _context.Product9144.Add(product9144);

            _context.Database.ExecuteSqlRaw("EXEC ADD_PRODUCT @PPRODNAME = " + p.Prodname +
                ", @PBUYPRICE = " + p.Buyprice +
                ", @PSELLPRICE = " + p.Sellprice);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct9144", new { id = p.Prodname }, p);
        }

        // DELETE: api/Product9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product9144>> DeleteProduct9144(int id)
        {
            var product9144 = await _context.Product9144.FindAsync(id);
            if (product9144 == null)
            {
                return NotFound();
            }

            _context.Product9144.Remove(product9144);
            await _context.SaveChangesAsync();

            return product9144;
        }

        private bool Product9144Exists(int id)
        {
            return _context.Product9144.Any(e => e.Productid == id);
        }
    }
}
