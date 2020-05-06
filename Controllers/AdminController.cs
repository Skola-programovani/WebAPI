using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.Web.Http.Cors;
using System.Text;  
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]

    public class AdminController : ControllerBase
    {
        private readonly MyContext _context;

        public AdminController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Admin

        [HttpGet]
        public IEnumerable<Admin> Get()
        {
            return _context.Admin;
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admin.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            if (id != admin.id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            StringBuilder passwordHash = new StringBuilder(512);
            using (SHA256 sha = SHA256.Create())
            {  
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(admin.password));
                foreach (byte b in bytes)
                passwordHash.AppendFormat("{0:x2}", b);
            }
            admin.password = passwordHash.ToString();
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.id }, admin);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(int id)
        {
            var admin = await _context.Admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        private bool AdminExists(int id)
        {
            return _context.Admin.Any(e => e.id == id);
        }
    }
}
