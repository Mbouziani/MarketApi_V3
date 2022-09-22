﻿using System;
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
    public class ClientCompaniesController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public ClientCompaniesController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/ClientCompanies
        [HttpGet]
        public async Task<ActionResult<Company>> GetClientCompanies([FromQuery] String username, String password )
        {
            var result= await _context.ClientCompanies.Where(cC => cC.CompanyUsernam == username && cC.CompanyPasswrod == password && cC.CompanyActiveStatus ==1).ToListAsync();

            if (!result.Any())
            {
                return NotFound();
            }

            Company company = new Company();
            company.CompanyNumber = result[0].CompanyNumber;
            company.CompanyName = result[0].CompanyName;
            company.CompanyTaxNumber = result[0].CompanyTaxNumber;
            company.CompanyPhone = result[0].CompanyPhone;
            company.CompanyAddress = result[0].CompanyAddress;
            company.CompanyCommercial = result[0].CompanyCommercial;

            return company;




        }

        // GET: api/ClientCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientCompany>> GetClientCompany(int id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);

            if (clientCompany == null)
            {
                return NotFound();
            }

            return clientCompany;
        }


        // PUT: api/ClientCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientCompany(int id, ClientCompany clientCompany)
        {
            if (id != clientCompany.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(clientCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCompanyExists(id))
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

        // POST: api/ClientCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientCompany>> PostClientCompany(ClientCompany clientCompany)
        {
            _context.ClientCompanies.Add(clientCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientCompany", new { id = clientCompany.CompanyId }, clientCompany);
        }

        // DELETE: api/ClientCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientCompany(int id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            _context.ClientCompanies.Remove(clientCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientCompanyExists(int id)
        {
            return _context.ClientCompanies.Any(e => e.CompanyId == id);
        }
    }
}
