using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;

namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public BranchesController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branche>>> GetBranches()
        {
          if (_context.Branches == null)
          {
              return NotFound();
          }
            return await _context.Branches.Include(c => c.Zones).OrderByDescending(b => b.BrancheId).ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branche>> GetBranche(int id)
        {
          if (_context.Branches == null)
          {
              return NotFound();
          }
            var branche = await _context.Branches.FindAsync(id);

            if (branche == null)
            {
                return NotFound();
            }

            return branche;
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranche(int id, Branche branche)
        {
            if (id != branche.BrancheId)
            {
                return BadRequest();
            }

            _context.Entry(branche).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrancheExists(id))
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

        // POST: api/Branches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Branche>> PostBranche(Branche branche)
        {
          if (_context.Branches == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Branches'  is null.");
          }
            _context.Branches.Add(branche);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranche", new { id = branche.BrancheId }, branche);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranche(int id)
        {
            if (_context.Branches == null)
            {
                return NotFound();
            }
            var branche = await _context.Branches.FindAsync(id);
            if (branche == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branche);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrancheExists(int id)
        {
            return (_context.Branches?.Any(e => e.BrancheId == id)).GetValueOrDefault();
        }
    }
}
