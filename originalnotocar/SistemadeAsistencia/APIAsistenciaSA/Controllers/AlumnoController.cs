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
    public class AlumnoController : ControllerBase
    {
        private readonly BDAsistencia3Context _context;

        public AlumnoController(BDAsistencia3Context context)
        {
            _context = context;
        }

        // GET: api/Alumno
        [HttpGet]
        public IEnumerable<Alumno> GetAlumno()
        {
            return _context.Alumno;
        }

        // GET: api/Alumno/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlumno([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alumno = await _context.Alumno.FindAsync(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return Ok(alumno);
        }

        // PUT: api/Alumno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno([FromRoute] int id, [FromBody] Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumno.Aluid)
            {
                return BadRequest();
            }

            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
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

        // POST: api/Alumno
        [HttpPost]
        public async Task<IActionResult> PostAlumno([FromBody] Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Alumno.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumno", new { id = alumno.Aluid }, alumno);
        }

        // DELETE: api/Alumno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumno.Remove(alumno);
            await _context.SaveChangesAsync();

            return Ok(alumno);
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumno.Any(e => e.Aluid == id);
        }
    }
}