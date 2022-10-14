using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;
using MARKET_API_V3.HelperCors;
#nullable enable
namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnsController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public ReturnsController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/Returns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Returne>>> GetReturnes([FromQuery] PagingMove paging,
            [FromQuery] String? returnNumber, String? reciepNumber, String? agentNumber, String? paymentMethode, String? zoneNumber)
        {
          if (_context.Returnes == null)
          {
              return NotFound();
          }
            var _return = await _context.Returnes.Include(c => c.Salereturneds).OrderByDescending(z => z. ReturnId).ToListAsync();
            if (!string.IsNullOrWhiteSpace(returnNumber))
            {
                _return = _return.Where(reciep => reciep.ReturnNumber == long.Parse(returnNumber)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(reciepNumber))
            {
                _return = _return.Where(reciep => reciep.ReturnreciepNumber == long.Parse(reciepNumber)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(agentNumber))
            {
                _return = _return.Where(reciep => reciep.ReturnAgentNumber == long.Parse(agentNumber)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(paymentMethode))
            {
                _return = _return.Where(reciep => reciep.ReturnPaymentMethode == paymentMethode).ToList();
            }
            if (!string.IsNullOrWhiteSpace(zoneNumber))
            {
                _return = _return.Where(reciep => reciep.ReturnZoneNumber == int.Parse(zoneNumber)).ToList();
            }
            var pagedResponse = new PagingResponse<Returne>(_return.AsQueryable(), paging);
            return Ok(pagedResponse);
        }
        

        // GET: api/Returns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Returne>> GetReturne(int id)
        {
          if (_context.Returnes == null)
          {
              return NotFound();
          }
            var Returne = await _context.Returnes.FindAsync(id);

            if (Returne == null)
            {
                return NotFound();
            }

            return Returne;
        }

        // PUT: api/Returns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturne(int id, Returne Returne)
        {
            if (id != Returne.ReturnId)
            {
                return BadRequest();
            }

            _context.Entry(Returne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturneExists(id))
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

        // POST: api/Returns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Returne>> PostReturne(Returne Returne)
        {
          if (_context.Returnes == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Returnes'  is null.");
          }
            _context.Returnes.Add(Returne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReturne", new { id = Returne.ReturnId }, Returne);
        }



        [HttpPost("ComplexeReturnData")]
        private async Task<ActionResult<Returne>> PostComplexeData([FromBody] Returne Returne)
        {
            SaleReturnedsController ctrlSaleReturn = new SaleReturnedsController(_context);
            if (_context.Returnes == null)
            {
                return Problem("Entity set is null.");
            }
            Returne? _return = PostReturne(Returne).Result.Value;
            if (_return == null) { return Problem("the user didnt get in "); }
            foreach (var _rsale in _return.Salereturneds)
            {
                _rsale.ReturnId = _return.ReturnId;
                await ctrlSaleReturn.PostSalereturned(_rsale);
            }
            return Returne;
        }



        [HttpPost("List")]
        public async Task<ActionResult<string>> PostListOfProducts([FromBody] List<Returne> _list)
        {
            if (_context.Returnes == null)
            {
                return Problem("Entity set is null.");
            }
            for (var i = 0; i < _list.Count; i++)
            {
                var _return = _list[i];
                await PostComplexeData(_return);
            }


            return _list.Count.ToString();
        }



        // DELETE: api/Returns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturne(int id)
        {
            if (_context.Returnes == null)
            {
                return NotFound();
            }
            var Returne = await _context.Returnes.FindAsync(id);
            if (Returne == null)
            {
                return NotFound();
            }

            _context.Returnes.Remove(Returne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReturneExists(int id)
        {
            return (_context.Returnes?.Any(e => e.ReturnId == id)).GetValueOrDefault();
        }


    }


}
