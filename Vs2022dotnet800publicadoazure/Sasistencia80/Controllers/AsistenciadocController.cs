using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;

namespace Sasistencia80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciadocController : ControllerBase
    {
        private readonly BdasistenciaContext _context;

        public AsistenciadocController(BdasistenciaContext context)
        {
            _context = context;
        }

        // GET: api/Asistenciadoc
        [HttpGet]
        public IEnumerable<Asistenciadoc> GetAsistenciadoc()
        {
            return _context.Asistenciadoc.ToList();
        }

        // GET: api/Asistenciadoc/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsistenciadoc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciadoc = await _context.Asistenciadoc.FindAsync(id);
            if (asistenciadoc == null)
            {
                return NotFound();
            }
            return Ok(asistenciadoc);
        }

        // PUT: api/Asistenciadoc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistenciadoc([FromRoute] int id, [FromBody] Asistenciadoc asistenciadoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != asistenciadoc.Fdpid)
            {
                return BadRequest();
            }
            _context.Entry(asistenciadoc).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciadocExists(id))
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

        // POST: api/Asistenciadoc
        [HttpPost]
        public async Task<IActionResult> PostAsistenciadoc([FromBody] Asistenciadoc asistenciadoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Asistenciadoc.Add(asistenciadoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsistenciadoc", new { id = asistenciadoc.Fdpid }, asistenciadoc);
        }

        // DELETE: api/Asistenciadoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistenciadoc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asistenciadoc = await _context.Asistenciadoc.FindAsync(id);
            if (asistenciadoc == null)
            {
                return NotFound();
            }

            _context.Asistenciadoc.Remove(asistenciadoc);
            await _context.SaveChangesAsync();

            return Ok(asistenciadoc);
        }

        private bool AsistenciadocExists(int id)
        {
            return _context.Asistenciadoc.Any(e => e.Fdpid == id);
        }
    }
}
