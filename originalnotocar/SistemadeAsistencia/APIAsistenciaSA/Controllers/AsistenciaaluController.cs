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
    public class AsistenciaaluController : ControllerBase
    {
        private readonly BDAsistencia3Context _context;

        public AsistenciaaluController(BDAsistencia3Context context)
        {
            _context = context;
        }

        // GET: api/Asistenciaalu
        [HttpGet]
        public IEnumerable<Asistenciaalu> GetAsistenciaalu()
        {
            return _context.Asistenciaalu;
        }

        // GET: api/Asistenciaalu/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsistenciaalu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asistenciaalu = await _context.Asistenciaalu.FindAsync(id);

            if (asistenciaalu == null)
            {
                return NotFound();
            }

            return Ok(asistenciaalu);
        }

        // PUT: api/Asistenciaalu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsistenciaalu([FromRoute] int id, [FromBody] Asistenciaalu asistenciaalu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asistenciaalu.Fecid)
            {
                return BadRequest();
            }

            _context.Entry(asistenciaalu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsistenciaaluExists(id))
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

        // POST: api/Asistenciaalu
        [HttpPost]
        public async Task<IActionResult> PostAsistenciaalu([FromBody] Asistenciaalu asistenciaalu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Asistenciaalu.Add(asistenciaalu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsistenciaalu", new { id = asistenciaalu.Fecid }, asistenciaalu);
        }

        // DELETE: api/Asistenciaalu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistenciaalu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asistenciaalu = await _context.Asistenciaalu.FindAsync(id);
            if (asistenciaalu == null)
            {
                return NotFound();
            }

            _context.Asistenciaalu.Remove(asistenciaalu);
            await _context.SaveChangesAsync();

            return Ok(asistenciaalu);
        }

        private bool AsistenciaaluExists(int id)
        {
            return _context.Asistenciaalu.Any(e => e.Fecid == id);
        }
    }
}