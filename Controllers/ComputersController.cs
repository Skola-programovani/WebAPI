using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly MyContext _context;

        public ComputersController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Computers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Klient>>> GetKlient()
        {
            return await _context.Klient.ToListAsync();
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Klient>> GetKlient(int id)
        {
            var klient = await _context.Klient.FindAsync(id);

            if (klient == null)
            {
                return NotFound();
            }

            return klient;
        }

        // PUT: api/Computers/5
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

        // POST: api/Computers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Klient>> PostKlient(Klient klient)
        {
            _context.Klient.Add(klient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKlient", new { id = klient.id }, klient);
        }

        // DELETE: api/Computers/5
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
