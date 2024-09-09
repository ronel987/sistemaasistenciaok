using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;

namespace Sasistencia80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly BdasistenciaContext BD;

        public AlumnoController(BdasistenciaContext context)
        {
            BD = context;
        }

        //GET. /api/alumno
        [HttpGet]
        public IEnumerable<Alumno> ListaDeAlumnos()
        {
            return BD.Alumno.ToList();         
        }

        // GET: api/Alumno/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlumno([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var alumno = await BD.Alumno.FindAsync(id);
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
            BD.Entry(alumno).State = EntityState.Modified;
            try
            {
                await BD.SaveChangesAsync();
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
            BD.Alumno.Add(alumno);
            await BD.SaveChangesAsync();
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
            var alumno = await BD.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            BD.Alumno.Remove(alumno);
            await BD.SaveChangesAsync();
            return Ok(alumno);
        }

        private bool AlumnoExists(int id)
        {
            return BD.Alumno.Any(e => e.Aluid == id);
        }


    }
}
