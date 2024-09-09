using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;

namespace Sasistencia80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly BdasistenciaContext _context;

        public CursoController(BdasistenciaContext context)
        {
            _context = context;
        }

        // GET: api/Curso
        [HttpGet]
        public IEnumerable<Curso> GetCurso()
        {
            return _context.Curso.ToList();
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurso([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/Curso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso([FromRoute] int id, [FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != curso.Curid)
            {
                return BadRequest();
            }
            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Curso
        [HttpPost]
        public async Task<IActionResult> PostCurso([FromBody] Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCurso", new { id = curso.Curid }, curso);
        }

        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return Ok(curso);
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Curid == id);
        }




    }
}
