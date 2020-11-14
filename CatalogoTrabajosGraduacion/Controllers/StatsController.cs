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
    public class StatsController : ControllerBase
    {
        private readonly trabajosGraduacionContext _context;

        public StatsController(trabajosGraduacionContext context)
        {
            _context = context;
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetGeneralStats()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join tip in _context.Tipo on t.Tipo equals tip.IdTipo
                             group tip by tip.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        // GET: api/Stats/statsByFaculty
        [Route("statsByFaculty")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetStatsByFaculty()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join car in _context.Carrera on t.Carrera equals car.IdCarrera
                             join fac in _context.Facultad on car.Facultad equals fac.IdFacultad
                             group fac by fac.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        // GET: api/Stats/statsByEngineering
        [Route("statsByEngineering")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetStatsByEngineering()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join tip in _context.Tipo on t.Tipo equals tip.IdTipo
                             join car in _context.Carrera on t.Carrera equals car.IdCarrera
                             join fac in _context.Facultad on car.Facultad equals fac.IdFacultad
                             where fac.IdFacultad == 1
                             group tip by tip.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        // GET: api/Stats/statsByBusinessSc
        [Route("statsByBusinessSc")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetStatsByBusinessSc()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join tip in _context.Tipo on t.Tipo equals tip.IdTipo
                             join car in _context.Carrera on t.Carrera equals car.IdCarrera
                             join fac in _context.Facultad on car.Facultad equals fac.IdFacultad
                             where fac.IdFacultad == 2
                             group tip by tip.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        // GET: api/Stats/statsByHumanitySc
        [Route("statsByHumanitySc")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetStatsByHumanitySc()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join tip in _context.Tipo on t.Tipo equals tip.IdTipo
                             join car in _context.Carrera on t.Carrera equals car.IdCarrera
                             join fac in _context.Facultad on car.Facultad equals fac.IdFacultad
                             where fac.IdFacultad == 3
                             group tip by tip.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        // GET: api/Stats/statsByHealthSc
        [Route("statsByHealthSc")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetStatsByHealthSc()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join tip in _context.Tipo on t.Tipo equals tip.IdTipo
                             join car in _context.Carrera on t.Carrera equals car.IdCarrera
                             join fac in _context.Facultad on car.Facultad equals fac.IdFacultad
                             where fac.IdFacultad == 4
                             group tip by tip.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        // GET: api/Stats/statsByCareers
        [Route("statsByCareers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetStatsByCareers()
        {
            var queryStats = from t in _context.TrabajosGraduacion
                             join car in _context.Carrera on t.Carrera equals car.IdCarrera
                             group car by car.Nombre into gr
                             select new
                             {
                                 Tipo = gr.Key,
                                 Cantidad = gr.Count()
                             };

            return await queryStats.ToListAsync();
        }

        private bool TrabajosGraduacionExists(int id)
        {
            return _context.TrabajosGraduacion.Any(e => e.IdTrabajo == id);
        }
    }
}
