using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;
using MARKET_API_V3.HelperCors;
using MarketApi_V3.HelperCors;
#nullable enable

namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciepsController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public ReciepsController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        

        // GET: api/Recieps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reciep>>> GetRecieps([FromQuery] PagingMove paging,
            [FromQuery] String? reciepNumber , String? agentNumber, String? paymentMethode, String? zoneNumber  )
        {
          if (_context.Recieps == null)
          {
              return NotFound();
          }

            var reciep = await _context.Recieps.Include(c => c.Sales).OrderByDescending(o=> o.ReciepId).ToListAsync();
            if (!string.IsNullOrWhiteSpace(reciepNumber))
            {
                reciep = reciep.Where(reciep => reciep.ReciepNumber == long.Parse (reciepNumber)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(agentNumber))
            {
                reciep = reciep.Where(reciep => reciep.ReciepAgentNumber == long.Parse(agentNumber)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(paymentMethode))
            {
                reciep = reciep.Where(reciep => reciep.ReciepPaymentMethode== paymentMethode ).ToList();
            }
            if (!string.IsNullOrWhiteSpace(zoneNumber))
            {
                reciep= reciep.Where(reciep => reciep.ReciepZoneNumber ==int.Parse( zoneNumber)).ToList();
            }
            var pagedResponse = new PagingResponse<Reciep>(reciep.AsQueryable(), paging  ) ;
            return Ok(pagedResponse);
        }
        // GET: api/Recieps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reciep>> GetReciep(int id)
        {
          if (_context.Recieps == null)
          {
              return NotFound();
          }
            var reciep = await _context.Recieps.FindAsync(id);

            if (reciep == null)
            {
                return NotFound();
            }

            return reciep;
        }

        // PUT: api/Recieps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciep(int id, Reciep reciep)
        {
            if (id != reciep.ReciepId)
            {
                return BadRequest();
            }

            _context.Entry(reciep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciepExists(id))
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

        // POST: api/Recieps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reciep>> PostReciep(Reciep reciep)
        {
          if (_context.Recieps == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Recieps'  is null.");
          }
            _context.Recieps.Add(reciep);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciep", new { id = reciep.ReciepId }, reciep);
        }

        [HttpPost("ComplexeReciepData")]
        private async Task<ActionResult<Reciep>> PostComplexeData(Reciep reciep)
        {
            SalesController ctrlSale = new SalesController(_context);
            if (_context.Recieps == null)
            {
                return Problem("Entity set 'demoTestDBContext.Owners'  is null.");
            }
            Reciep? _reciep = PostReciep(reciep).Result.Value;
            if (_reciep == null) { return Problem("the user didnt get in "); }
            foreach (var _sale in _reciep.Sales)
            {
                _sale.ReciepId = _reciep.ReciepId;
                await ctrlSale.PostSale(_sale);
            }
            return reciep;
        }



        [HttpPost("List")]
        public async Task<ActionResult<string>> PostListOfProducts([FromBody] List<Reciep> _list)
        {
            if (_context.Recieps == null)
            {
                return Problem("Entity set is null.");
            }
            for (var i = 0; i < _list.Count; i++)
            {
                var _reciep = _list[i];
                await PostComplexeData(_reciep);
            }


            return _list.Count.ToString();
        }



        // DELETE: api/Recieps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReciep(int id)
        {
            if (_context.Recieps == null)
            {
                return NotFound();
            }
            var reciep = await _context.Recieps.FindAsync(id);
            if (reciep == null)
            {
                return NotFound();
            }

            _context.Recieps.Remove(reciep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReciepExists(int id)
        {
            return (_context.Recieps?.Any(e => e.ReciepId == id)).GetValueOrDefault();
        }


     
    }
}
