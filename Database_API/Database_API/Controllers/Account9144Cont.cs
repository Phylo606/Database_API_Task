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
    class Account9144Cont : ControllerBase
    {
        private readonly _102119144Context _context;

        public Account9144Cont(_102119144Context context)
        {
            _context = context;
        }

        // GET: api/Clientaccount9144
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account9144>>> GetClientaccount9144()
        {
            return await _context.Account9144.ToListAsync();
        }

        // GET: api/Clientaccount9144/5
        [HttpGet("{id}")]
        public async Task<List<AuthorisedAccounts9144>> GetClientaccount9144(int id)
        {
            // var clientaccount9144 = await _context.Clientaccount9144.FindAsync(id);

            // var account = await Task.FromResult(_context.Clientaccount9144.Include(x => x.Authorisedperson9144).ToList());

            var account = await Task.FromResult(_context.AuthorisedAccounts9144.FromSqlRaw("EXEC GET_CLIENT_ACCOUNT_BY_ID @PACCOUNTID = " + id).ToList());

            /*
            if (account == null)
            {   
                return NotFound();
            }
            */

            return account;
        }

        // PUT: api/Clientaccount9144/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientaccount9144(int id, Account9144 clientaccount9144)
        {
            if (id != clientaccount9144.acctId)
            {
                return BadRequest();
            }

            _context.Entry(clientaccount9144).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Clientaccount9144Exists(id))
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

        // POST: api/Clientaccount9144
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Account9144>> PostClientaccount9144(Account9144 c)
        {
            // _context.Clientaccount9144.Add(clientaccount9144);


            var accountID = await Task.FromResult(_context.Account9144.FromSqlRaw("EXEC ADD_CLIENT_ACCOUNT @PACCTNAME = " + c.acctName +
                ", @PBALANCE = " + c.acctBalance +
                ", @PCREDITLIMIT = " + c.credLimit).ToList());

            // await _context.SaveChangesAsync();
            return accountID[0];
        }

        // DELETE: api/Clientaccount9144/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account9144>> DeleteClientaccount9144(int id)
        {
            var clientaccount9144 = await _context.Account9144.FindAsync(id);
            if (clientaccount9144 == null)
            {
                return NotFound();
            }

            _context.Account9144.Remove(clientaccount9144);
            await _context.SaveChangesAsync();

            return clientaccount9144;
        }

        private bool Clientaccount9144Exists(int id)
        {
            return _context.Account9144.Any(e => e.acctId == id);
        }
    }
}
