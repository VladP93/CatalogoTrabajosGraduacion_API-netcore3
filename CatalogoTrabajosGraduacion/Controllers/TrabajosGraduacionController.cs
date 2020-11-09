using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoTrabajosGraduacion.Models;

namespace CatalogoTrabajosGraduacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosGraduacionController : ControllerBase
    {
        private readonly trabajosGraduacionContext _context;

        public TrabajosGraduacionController(trabajosGraduacionContext context)
        {
            _context = context;
        }

        // GET: api/TrabajosGraduacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetTrabajosGraduacion()
        {
            var queryTrabajosGraduacion = from t in _context.TrabajosGraduacion
                                          join tip in _context.Tipo on t.Tipo equals tip.IdTipo
                                          join car in _context.Carrera on t.Carrera equals car.IdCarrera
                                          join fac in _context.Facultad on car.Facultad equals fac.IdFacultad
                                          select new {
                                              t.Titulo,
                                              t.Autor,
                                              t.Anio,
                                              Facultad = fac.Nombre,
                                              Carrera = car.Nombre,
                                              Tipo = tip.Nombre
                                          };

            return await queryTrabajosGraduacion.ToListAsync();
        }

        // GET: api/TrabajosGraduacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajosGraduacion>> GetTrabajosGraduacion(int id)
        {
            var trabajosGraduacion = await _context.TrabajosGraduacion.FindAsync(id);

            if (trabajosGraduacion == null)
            {
                return NotFound();
            }

            return trabajosGraduacion;
        }

        // PUT: api/TrabajosGraduacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajosGraduacion(int id, TrabajosGraduacion trabajosGraduacion)
        {
            if (id != trabajosGraduacion.IdTrabajo)
            {
                return BadRequest();
            }

            _context.Entry(trabajosGraduacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajosGraduacionExists(id))
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

        // POST: api/TrabajosGraduacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrabajosGraduacion>> PostTrabajosGraduacion(TrabajosGraduacion trabajosGraduacion)
        {
            _context.TrabajosGraduacion.Add(trabajosGraduacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajosGraduacion", new { id = trabajosGraduacion.IdTrabajo }, trabajosGraduacion);
        }

        // DELETE: api/TrabajosGraduacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrabajosGraduacion>> DeleteTrabajosGraduacion(int id)
        {
            var trabajosGraduacion = await _context.TrabajosGraduacion.FindAsync(id);
            if (trabajosGraduacion == null)
            {
                return NotFound();
            }

            _context.TrabajosGraduacion.Remove(trabajosGraduacion);
            await _context.SaveChangesAsync();

            return trabajosGraduacion;
        }

        private bool TrabajosGraduacionExists(int id)
        {
            return _context.TrabajosGraduacion.Any(e => e.IdTrabajo == id);
        }
    }
}
