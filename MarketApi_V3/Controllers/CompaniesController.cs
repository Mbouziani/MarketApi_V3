using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;
using MarketApi_V3.HelperCors;
using MarketApi_V3.Models.DTO_Response;

namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public CompaniesController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<CompanyDTO>> GetCompanies()
        {
            // Status Of Return 
            //------------------------------------------------
            // 1- return 'Data' is mean login with Successe 
            // 2- return '0' is mean is not Found 
            //------------------------------------------------
            var company = await _context.Companies.ToListAsync();
            if (company.Any())
            {
                var result = await _context.Companies.Include(b => b.Branches).Select(c => new CompanyDTO()
                {
                    CompanyId = c.CompanyId,
                    CompanyNumber = c.CompanyNumber,
                    CompanyName = c.CompanyName,
                    CompanyAddress = c.CompanyAddress,
                    CompanyCommercial = c.CompanyCommercial,
                    CompanyFractionDigits = c.CompanyFractionDigits,
                    CompanyLink = c.CompanyLink,
                    CompanyPhone = c.CompanyPhone,
                    CompanyTaxNumber = c.CompanyTaxNumber,
                    CompanyZoneCount = c.CompanyZoneCount,
                    Branches = (ICollection<BrancheDTO>)c.Branches!.Select(br => new BrancheDTO()
                    {
                        BrancheId = br.BrancheId,
                        BrancheAddress = br.BrancheAddress,
                        BrancheName = br.BrancheName,
                        BrancheDirector = br.BrancheDirector,
                        BrancheNumber = br.BrancheNumber,
                        BranchePhone = br.BranchePhone,
                        CompanyId = br.CompanyId,
                        Zones = (ICollection<ZoneDTO>)br.Zones!.Select(z => new ZoneDTO()
                        {
                            ZoneId = z.ZoneId,
                            ZoneName = z.ZoneName,
                            ZoneAddress = z.ZoneAddress,
                            ZoneDirector = z.ZoneDirector,
                            ZoneNumber = z.ZoneNumber,
                            ZonePhone = z.ZonePhone,
                            ZoneTax = z.ZoneTax,
                            ZoneType = z.ZoneType,
                            BrancheId = z.BrancheId,
                            CompanyId = z.CompanyId,
                            ZoneReturnCount = z.Returnes.Count(),
                            ZoneReciepCount = z.Recieps.Count(),

                        }),
                    }),
                }).FirstAsync();
                return Ok(result);
            }
            else
            {
                return Ok(0);
            }
        }
            

        // GET: api/Companies
        [HttpGet("Statistic")]
        public async Task<ActionResult> GetStatistic()
        {
            var company = await _context.Companies.ToListAsync();
            if (company.Any())
            {
                Statistique _static = new Statistique();
                var result = await _static.getStatic(_context);
                return result == null ?Ok(0):Ok(result);
            }
            else
            {
                return Ok(0);
            }
         
        }

        // GET: api/Companies
        [HttpGet("CheckUrl")]
        public ActionResult CheckUrl(long val) => Ok(val);

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
          if (_context.Companies == null)
          {
              return NotFound();
          }
            
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
          if (_context.Companies == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Companies'  is null.");
          }
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (_context.Companies == null)
            {
                return NotFound();
            }
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return (_context.Companies?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
