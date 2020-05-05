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
        public async Task<ActionResult<IEnumerable<TemplateLink>>> GetTemplatelink()
        {
            return await _context.TemplateLink.ToListAsync();
        }

        // GET: api/Templatelink/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateLink>> GetTemplatelink(int id)
        {
            var templatelink = await _context.TemplateLink.FindAsync(id);

            if (templatelink == null)
            {
                return NotFound();
            }

            return templatelink;
        }
         // GET: api/Templatelink/user/5
        [HttpGet("user/{UserId}")]
        public async Task<ActionResult<TemplateLink>> GetTemplateID(int UserId)
        {
            var templateId = _context.TemplateLink.Where(x => x.idKlient == UserId).FirstOrDefault();

            if (templateId == null)
            {
                return NotFound();
            }
            return templateId;
        }

        // PUT: api/Templatelink/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplatelink(int id, TemplateLink templatelink)
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
        public async Task<ActionResult<TemplateLink>> PostTemplatelink(TemplateLink templatelink)
        {
            _context.TemplateLink.Add(templatelink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemplatelink", new { id = templatelink.id }, templatelink);
        }

        // DELETE: api/Templatelink/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TemplateLink>> DeleteTemplatelink(int id)
        {
            var templatelink = await _context.TemplateLink.FindAsync(id);
            if (templatelink == null)
            {
                return NotFound();
            }

            _context.TemplateLink.Remove(templatelink);
            await _context.SaveChangesAsync();

            return templatelink;
        }

        private bool TemplatelinkExists(int id)
        {
            return _context.TemplateLink.Any(e => e.id == id);
        }
    }
}
