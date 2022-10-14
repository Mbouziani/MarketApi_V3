﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketApi_V3.Models;
using MARKET_API_V3.HelperCors;
using MarketApi_V3.HelperCors;

namespace MarketApi_V3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly MarketManagementV2DBContext _context;

        public AgentsController(MarketManagementV2DBContext context)
        {
            _context = context;
        }

        // GET: api/Agents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents([FromQuery] PagingMove paging)
        {
            if (_context.Agents == null)
            {
                return NotFound();
            }
            var _agent = await _context.Agents.OrderByDescending(a => a.AgentId).ToListAsync();
           
            var pagedResponse = new PagingResponse<Agent>(_agent.AsQueryable(), paging);
           


            return Ok(pagedResponse);
        }



       



        // GET: api/Products
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAllAgents()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Agents.
                           ToListAsync();

        }

        // GET: api/Agents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetAgent(int id)
        {
          if (_context.Agents == null)
          {
              return NotFound();
          }
            var agent = await _context.Agents.FindAsync(id);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        // PUT: api/Agents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgent(int id, Agent agent)
        {
            if (id != agent.AgentId)
            {
                return BadRequest();
            }

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(id))
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

        // POST: api/Agents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agent>> PostAgent(Agent agent)
        {
          if (_context.Agents == null)
          {
              return Problem("Entity set 'MarketManagementV2DBContext.Agents'  is null.");
          }
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgent", new { id = agent.AgentId }, agent);
        }

        [HttpPost("List")]
        public async Task<ActionResult<string>> PostListOfAgents([FromBody] List<Agent> _list)
        {
            if (_context.Agents == null)
            {
                return Problem("Entity set  is null.");
            }
            for (int i = 0; i < _list.Count; i++)
            {
                _context.Agents.Add(_list[i]);
                await _context.SaveChangesAsync();
            }

            return Ok(_list.Count.ToString());
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgent(int id)
        {
            if (_context.Agents == null)
            {
                return NotFound();
            }
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgentExists(int id)
        {
            return (_context.Agents?.Any(e => e.AgentId == id)).GetValueOrDefault();
        }
    }
}
