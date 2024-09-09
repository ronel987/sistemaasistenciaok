using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;

namespace Sasistencia80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariodocController : ControllerBase
    {
        private readonly BdasistenciaContext _context;

        public HorariodocController(BdasistenciaContext context)
        {
            _context = context;
        }

        // GET: api/Horariodoc
        [HttpGet]
        public IEnumerable<Horariodoc> GetHorariodoc()
        {
            return _context.Horariodoc.ToList();
        }

        // GET: api/Horariodoc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHorariodoc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var horariodoc = await _context.Horariodoc.FindAsync(id);
            if (horariodoc == null)
            {
                return NotFound();
            }
            return Ok(horariodoc);
        }

        // PUT: api/Horariodoc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorariodoc([FromRoute] int id, [FromBody] Horariodoc horariodoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != horariodoc.Hcid)
            {
                return BadRequest();
            }
            _context.Entry(horariodoc).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorariodocExists(id))
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

        // POST: api/Horariodoc
        [HttpPost]
        public async Task<IActionResult> PostHorariodoc([FromBody] Horariodoc horariodoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Horariodoc.Add(horariodoc);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHorariodoc", new { id = horariodoc.Hcid }, horariodoc);
        }

        // DELETE: api/Horariodoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorariodoc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var horariodoc = await _context.Horariodoc.FindAsync(id);
            if (horariodoc == null)
            {
                return NotFound();
            }
            _context.Horariodoc.Remove(horariodoc);
            await _context.SaveChangesAsync();
            return Ok(horariodoc);
        }

        private bool HorariodocExists(int id)
        {
            return _context.Horariodoc.Any(e => e.Hcid == id);
        }


    }
}
