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
    public class SaleReturnedsController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public SaleReturnedsController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/SaleReturneds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salereturned>>> GetSalereturneds()
        {
          if (_context.Salereturneds == null)
          {
              return NotFound();
          }
            return await _context.Salereturneds.ToListAsync();
        }

        // GET: api/SaleReturneds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salereturned>> GetSalereturned(int id)
        {
          if (_context.Salereturneds == null)
          {
              return NotFound();
          }
            var salereturned = await _context.Salereturneds.FindAsync(id);

            if (salereturned == null)
            {
                return NotFound();
            }

            return salereturned;
        }

        // PUT: api/SaleReturneds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalereturned(int id, Salereturned salereturned)
        {
            if (id != salereturned.RsaleId)
            {
                return BadRequest();
            }

            _context.Entry(salereturned).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalereturnedExists(id))
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

        // POST: api/SaleReturneds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salereturned>> PostSalereturned(Salereturned salereturned)
        {
          if (_context.Salereturneds == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Salereturneds'  is null.");
          }
            _context.Salereturneds.Add(salereturned);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalereturned", new { id = salereturned.RsaleId }, salereturned);
        }

        // DELETE: api/SaleReturneds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalereturned(int id)
        {
            if (_context.Salereturneds == null)
            {
                return NotFound();
            }
            var salereturned = await _context.Salereturneds.FindAsync(id);
            if (salereturned == null)
            {
                return NotFound();
            }

            _context.Salereturneds.Remove(salereturned);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalereturnedExists(int id)
        {
            return (_context.Salereturneds?.Any(e => e.RsaleId == id)).GetValueOrDefault();
        }
    }
}
