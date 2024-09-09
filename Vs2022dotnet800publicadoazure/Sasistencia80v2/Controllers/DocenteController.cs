using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;

namespace Sasistencia80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly BdasistenciaContext _context;

        public DocenteController(BdasistenciaContext context)
        {
            _context = context;
        }

        // GET: api/Docente
        [HttpGet]
        public IEnumerable<Docente> GetDocente()
        {
            try
            {
                return _context.Docente.ToList();
            }catch (Exception ex)
            {
                return (IEnumerable<Docente>)NotFound();
            }
           
        }

        // GET: api/Docente/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var docente = await _context.Docente.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }
            return Ok(docente);
        }

        // PUT: api/Docente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocente([FromRoute] int id, [FromBody] Docente docente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != docente.Docid)
            {
                return BadRequest();
            }
            _context.Entry(docente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocenteExists(id))
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

        // POST: api/Docente
        [HttpPost]
        public async Task<IActionResult> PostDocente([FromBody] Docente docente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Docente.Add(docente);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDocente", new { id = docente.Docid }, docente);
        }

        // DELETE: api/Docente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var docente = await _context.Docente.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }

            _context.Docente.Remove(docente);
            await _context.SaveChangesAsync();

            return Ok(docente);
        }

        private bool DocenteExists(int id)
        {
            return _context.Docente.Any(e => e.Docid == id);
        }
    }
}
