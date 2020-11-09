﻿using System;
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
    public class TiposController : ControllerBase
    {
        private readonly trabajosGraduacionContext _context;

        public TiposController(trabajosGraduacionContext context)
        {
            _context = context;
        }

        // GET: api/Tipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipo()
        {
            return await _context.Tipo.ToListAsync();
        }

        // GET: api/Tipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> GetTipo(int id)
        {
            var tipo = await _context.Tipo.FindAsync(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return tipo;
        }

        // PUT: api/Tipos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, Tipo tipo)
        {
            if (id != tipo.IdTipo)
            {
                return BadRequest();
            }

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoExists(id))
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

        // POST: api/Tipos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tipo>> PostTipo(Tipo tipo)
        {
            _context.Tipo.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipo", new { id = tipo.IdTipo }, tipo);
        }

        // DELETE: api/Tipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipo>> DeleteTipo(int id)
        {
            var tipo = await _context.Tipo.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.Tipo.Remove(tipo);
            await _context.SaveChangesAsync();

            return tipo;
        }

        private bool TipoExists(int id)
        {
            return _context.Tipo.Any(e => e.IdTipo == id);
        }
    }
}
