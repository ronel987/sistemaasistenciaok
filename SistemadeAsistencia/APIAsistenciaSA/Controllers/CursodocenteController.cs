using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAsistenciaSA.Models;

namespace APIAsistenciaSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursodocenteController : ControllerBase
    {
        private readonly BDAsistencia3Context _context;

        public CursodocenteController(BDAsistencia3Context context)
        {
            _context = context;
        }

        // GET: api/Cursodocente
        [HttpGet]
        public IEnumerable<Cursodocente> GetCursodocente()
        {
            return _context.Cursodocente;
        }

        // GET: api/Cursodocente/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCursodocente([FromRoute] int id)
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

            return Ok(cursodocente);
        }

        // PUT: api/Cursodocente/5
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

        // POST: api/Cursodocente
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

        // DELETE: api/Cursodocente/5
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