using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;

namespace Sasistencia80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursodocenteController : ControllerBase
    {
        private readonly BdasistenciaContext _context;

        public CursodocenteController(BdasistenciaContext context)
        {
            _context = context;
        }

        // GET: api/Cursodocente
        [HttpGet]
        public IEnumerable<Cursodocente> GetCursodocente()
        {   try
            {
                return _context.Cursodocente.ToList();
            }catch (Exception ex)
            {
                return (IEnumerable<Cursodocente>)NotFound();
            }            
        }

        // GET: api/Cursodocente/2/3     pk compuesta si funca
        [HttpGet("{id1}/{id2}")]
        public async Task<IActionResult> GetCursodocente([FromRoute] int id1, [FromRoute] int id2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cursodocente = await _context.Cursodocente.FindAsync(id1,id2);
            if (cursodocente == null)
            {
                return NotFound();
            }
            return Ok(cursodocente);
        }

        // PUT: api/Cursodocente/5/3
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursodocente([FromRoute] int id, [FromBody] Cursodocente cursodocente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != cursodocente.Curid)
            {
                return BadRequest();
            }
            _context.Entry(cursodocente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursodocenteExists(id))
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

        // POST: api/Cursodocente     no funca
        [HttpPost]
        public async Task<IActionResult> PostCursodocente([FromBody] Cursodocente cursodocente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Cursodocente.Add(cursodocente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CursodocenteExists(cursodocente.Curid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetCursodocente", new { id = cursodocente.Curid }, cursodocente);
        }

        // DELETE: api/Cursodocente/5/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursodocente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cursodocente = await _context.Cursodocente.FindAsync(id);
            if (cursodocente == null)
            {
                return NotFound();
            }
            _context.Cursodocente.Remove(cursodocente);
            await _context.SaveChangesAsync();
            return Ok(cursodocente);
        }

        private bool CursodocenteExists(int id)
        {
            return _context.Cursodocente.Any(e => e.Curid == id);
        }




    }
}
