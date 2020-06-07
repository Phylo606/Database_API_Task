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
    public class AuthorisedPerson9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public AuthorisedPerson9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Authorisedperson9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorisedPerson9144>>> GetAuthorisedperson9144()
        {
            return await _context.AuthorisedPerson9144.ToListAsync();
        }

        // GET: api/Authorisedperson9144/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorisedPerson9144>> GetAuthorisedperson9144(int id)
        {
            var authorisedperson9144 = await _context.AuthorisedPerson9144.FindAsync(id);

            if (authorisedperson9144 == null)
            {
                return NotFound();
            }

            return authorisedperson9144;
        }

        // PUT: api/Authorisedperson9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorisedperson9144(int id, AuthorisedPerson9144 authorisedperson9144)
        {
            if (id != authorisedperson9144.userID)
            {
                return BadRequest();
            }

            _context.Entry(authorisedperson9144).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Authorisedperson9144Exists(id))
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

        // POST: api/Authorisedperson9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AuthorisedPerson9144>> PostAuthorisedperson9144(AuthorisedPerson9144 ap)
        {
            // _context.Authorisedperson9144.Add(authorisedperson9144);


            var authorisedPersonAccountID = await Task.FromResult(_context.AuthorisedPerson9144.FromSqlRaw("EXEC ADD_AUTHORISED_PERSON " +
                "@PFIRSTNAME = " + ap.Firstname +
                ", @PSURNAME = " + ap.Lastname +
                ", @PEMAIL = " + ap.Email +
                ", @PPASSWORD = " + ap.Password +
                ", @PACCOUNTID = " + ap.accountID).ToList());

            // await _context.SaveChangesAsync();

            return authorisedPersonAccountID[0];
        }

        // DELETE: api/Authorisedperson9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorisedPerson9144>> DeleteAuthorisedperson9144(int id)
        {
            var authorisedperson9144 = await _context.AuthorisedPerson9144.FindAsync(id);
            if (authorisedperson9144 == null)
            {
                return NotFound();
            }

            _context.AuthorisedPerson9144.Remove(authorisedperson9144);
            await _context.SaveChangesAsync();

            return authorisedperson9144;
        }

        private bool Authorisedperson9144Exists(int id)
        {
            return _context.AuthorisedPerson9144.Any(e => e.userID == id);
        }
    }
}
