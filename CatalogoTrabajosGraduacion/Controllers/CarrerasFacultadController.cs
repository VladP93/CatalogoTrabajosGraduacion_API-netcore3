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
    public class CarrerasFacultadController : ControllerBase
    {
        private readonly trabajosGraduacionContext _context;

        public CarrerasFacultadController(trabajosGraduacionContext context)
        {
            _context = context;
        }

        // GET: api/CarrerasFacultad/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Carrera>> GetCarrera(int id)
        {
            var carrera = await _context.Carrera.AsQueryable().Where(x=>x.Facultad == id).ToArrayAsync();

            if (carrera == null)
            {
                return null;
            }

            return carrera;
        }

        private bool CarreraExists(int id)
        {
            return _context.Carrera.Any(e => e.IdCarrera == id);
        }
    }
}
