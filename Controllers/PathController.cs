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
    public class PathController : ControllerBase
    {
        private readonly MyContext _context;

        public PathController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Path
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Path>>> GetPath()
        {
            return await _context.Path.ToListAsync();
        }

        // GET: api/Path/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Path>> GetPath(int id)
        {
            var path = await _context.Path.FindAsync(id);

            if (path == null)
            {
                return NotFound();
            }

            return path;
        }

        // PUT: api/Path/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPath(int id, Path path)
        {
            if (id != path.id)
            {
                return BadRequest();
            }

            _context.Entry(path).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PathExists(id))
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

        // POST: api/Path
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Path>> PostPath(Path path)
        {
            _context.Path.Add(path);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPath", new { id = path.id }, path);
        }

        // DELETE: api/Path/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Path>> DeletePath(int id)
        {
            var path = await _context.Path.FindAsync(id);
            if (path == null)
            {
                return NotFound();
            }

            _context.Path.Remove(path);
            await _context.SaveChangesAsync();

            return path;
        }

        private bool PathExists(int id)
        {
            return _context.Path.Any(e => e.id == id);
        }
    }
}
