using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using management_api.Models;

namespace management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectdetailsController : ControllerBase
    {
        private readonly taskmanagementContext _context;

        public ProjectdetailsController(taskmanagementContext context)
        {
            _context = context;
        }

        // GET: api/Projectdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projectdetail>>> GetProjectdetails()
        {
            return await _context.Projectdetails.ToListAsync();
        }

        // GET: api/Projectdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projectdetail>> GetProjectdetail(int id)
        {
            var projectdetail = await _context.Projectdetails.FindAsync(id);

            if (projectdetail == null)
            {
                return NotFound();
            }

            return projectdetail;
        }

        // PUT: api/Projectdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectdetail(int id, Projectdetail projectdetail)
        {
            if (id != projectdetail.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(projectdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectdetailExists(id))
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

        // POST: api/Projectdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projectdetail>> PostProjectdetail(Projectdetail projectdetail)
        {
            _context.Projectdetails.Add(projectdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectdetail", new { id = projectdetail.ProjectId }, projectdetail);
        }

        // DELETE: api/Projectdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectdetail(int id)
        {
            var projectdetail = await _context.Projectdetails.FindAsync(id);
            if (projectdetail == null)
            {
                return NotFound();
            }

            _context.Projectdetails.Remove(projectdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectdetailExists(int id)
        {
            return _context.Projectdetails.Any(e => e.ProjectId == id);
        }
    }
}
