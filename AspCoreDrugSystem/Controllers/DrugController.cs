using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspCoreDrugSystem.Models;
using AspCoreDrugSystem.Data;

namespace AspCoreDrugSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly DrugContext _context;
        private readonly IDataRepository<Drug> _repo;

        public DrugController(DrugContext context, IDataRepository<Drug> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/Drugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs()
        {
            return await _context.Drugs.ToListAsync();
        }

        // GET: api/Drugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug([FromRoute] int id)
        {
            var drug = await _context.Drugs.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }


        // PUT: api/Drugs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug([FromRoute] int id, [FromBody] Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drug.DrugId)
            {
                return BadRequest();
            }

            _context.Entry(drug).State = EntityState.Modified;

            try
            {
                _repo.Update(drug);
                var save = await _repo.SaveAsync(drug);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
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

        // POST: api/Drugs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Drug>> PostDrug([FromBody] Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var save = await _repo.SaveAsync(drug);

            return CreatedAtAction("GetDrug", new { id = drug.DrugId }, drug);
        }

        // DELETE: api/Drugs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Drug>> DeleteDrug([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }

            _repo.Delete(drug);
            var save = await _repo.SaveAsync(drug);

            return Ok(drug);
        }

        private bool DrugExists(int id)
        {
            return _context.Drugs.Any(e => e.DrugId == id);
        }
    }
}
