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
    public class TemplatelinkController : ControllerBase
    {
        private readonly MyContext _context;

        public TemplatelinkController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Templatelink
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Templatelink>>> GetTemplatelink()
        {
            return await _context.Templatelink.ToListAsync();
        }

        // GET: api/Templatelink/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Templatelink>> GetTemplatelink(int id)
        {
            var templatelink = await _context.Templatelink.FindAsync(id);

            if (templatelink == null)
            {
                return NotFound();
            }

            return templatelink;
        }

        // PUT: api/Templatelink/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplatelink(int id, Templatelink templatelink)
        {
            if (id != templatelink.id)
            {
                return BadRequest();
            }

            _context.Entry(templatelink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplatelinkExists(id))
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

        // POST: api/Templatelink
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Templatelink>> PostTemplatelink(Templatelink templatelink)
        {
            _context.Templatelink.Add(templatelink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemplatelink", new { id = templatelink.id }, templatelink);
        }

        // DELETE: api/Templatelink/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Templatelink>> DeleteTemplatelink(int id)
        {
            var templatelink = await _context.Templatelink.FindAsync(id);
            if (templatelink == null)
            {
                return NotFound();
            }

            _context.Templatelink.Remove(templatelink);
            await _context.SaveChangesAsync();

            return templatelink;
        }

        private bool TemplatelinkExists(int id)
        {
            return _context.Templatelink.Any(e => e.id == id);
        }
    }
}
