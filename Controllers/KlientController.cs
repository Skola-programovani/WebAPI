using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class KlientController : ControllerBase
    {
        private readonly MyContext _context;

        public KlientController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Klient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klient>>> GetKlient()
        {
            return await _context.Klient.ToListAsync();
        }

        // GET: api/Klient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Klient>> GetKlient(string id)
        {
            var klient = await _context.Klient.FindAsync(id);

            if (klient == null)

            {
                return NotFound();
            }
            return klient;
        }

         // GET: api/Klient/mac/acAddr
        [HttpGet("mac/{MacAddr}")]
        public async Task<ActionResult<Klient>> GetKlientMac(string MacAddr)
        {
            var klient = _context.Klient.Where(x => x.MAC == MacAddr).FirstOrDefault();

            if (klient == null)
            {
                return NotFound();
            }


            return klient;
        }

        // PUT: api/Klient/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlient(int id, Klient klient)
        {
            if (id != klient.id)
            {
                return BadRequest();
            }

            _context.Entry(klient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlientExists(id))
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

        // POST: api/Klient
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Klient>> PostKlient(Klient klient)
        {
            _context.Klient.Add(klient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKlient", new { id = klient.id }, klient);
        }

        // DELETE: api/Klient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Klient>> DeleteKlient(int id)
        {
            var klient = await _context.Klient.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }

            _context.Klient.Remove(klient);
            await _context.SaveChangesAsync();

            return klient;
        }

        private bool KlientExists(int id)
        {
            return _context.Klient.Any(e => e.id == id);
        }
    }
}
