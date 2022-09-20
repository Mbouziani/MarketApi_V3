using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;
using MARKET_API_V3.HelperCors;

namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public ZonesController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZones([FromQuery] PagingMove paging)
        {
          if (_context.Zones == null)
          {
              return NotFound();
          } 
            var _result = await _context.Zones.OrderByDescending(z => z.ZoneId). ToListAsync();


            var pagedResponse = new PagingResponse<Zone>(_result.AsQueryable(), paging);
            return Ok(pagedResponse);



        }

        // GET: api/Zones/5
        [HttpGet("{number}")]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZone(long number)
        {
          if (_context.Zones == null)
          {
              return NotFound();
          }
            var zone =  await _context.Zones.Include(z => z.Company).Include(z => z.Branche).Where(_zone => _zone.ZoneNumber == number)
                .ToListAsync();
            

           

            return Ok(zone);
        }

        // PUT: api/Zones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZone(int id, Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return BadRequest();
            }

            _context.Entry(zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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

        // POST: api/Zones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone)
        {
          if (_context.Zones == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Zones'  is null.");
          }
            _context.Zones.Add(zone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZone", new { id = zone.ZoneId }, zone);
        }

        // DELETE: api/Zones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone(int id)
        {
            if (_context.Zones == null)
            {
                return NotFound();
            }
            var zone = await _context.Zones.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZoneExists(int id)
        {
            return (_context.Zones?.Any(e => e.ZoneId == id)).GetValueOrDefault();
        }
    }
}
