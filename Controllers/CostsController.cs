using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlTrmWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace InlTrmWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CostsController : ControllerBase
    {
        private readonly INLTRMContext _context;

        public CostsController(INLTRMContext context)
        {
            _context = context;
        }

        // GET: api/Costs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Costs>>> GetCosts()
        {
            return await _context.Costs.ToListAsync();
        }

        // GET: api/Costs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Costs>> GetCosts(int id)
        {
            var costs = await _context.Costs.FindAsync(id);

            if (costs == null)
            {
                return NotFound();
            }

            return costs;
        }

        // PUT: api/Costs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCosts(int id, Costs costs)
        {
            if (id != costs.CostId)
            {
                return BadRequest();
            }

            _context.Entry(costs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostsExists(id))
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

        // POST: api/Costs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Costs>> PostCosts(Costs costs)
        {
            _context.Costs.Add(costs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CostsExists(costs.CostId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCosts", new { id = costs.CostId }, costs);
        }

        // DELETE: api/Costs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Costs>> DeleteCosts(int id)
        {
            var costs = await _context.Costs.FindAsync(id);
            if (costs == null)
            {
                return NotFound();
            }

            _context.Costs.Remove(costs);
            await _context.SaveChangesAsync();

            return costs;
        }

        private bool CostsExists(int id)
        {
            return _context.Costs.Any(e => e.CostId == id);
        }
    }
}
