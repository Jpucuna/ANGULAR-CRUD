using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDPrueba.DataAccess;
using BDPrueba.Models;

namespace BDPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PruebaContext _context;

        public PersonasController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public IEnumerable<Persona> Get()
        {


            var lst = (from d in _context.Personas
                       from d1 in _context.Sectors
                       from d2 in _context.Zonas

                       where d.CodZona == d2.CodZona && d.CodSector == d1.CodSector
                       select new Persona
                       {

                           CodPersona = d.CodPersona,

                           NomPersona = d.NomPersona,

                           FecNac = d.FecNac,

                           CodSector = d.CodSector,

                           CodZona = d.CodZona,

                           Sueldo = d.Sueldo,

                       }).ToList();

            return lst;


        }

        //CONSULTA LAS PERSONAS QUE VIVEN EN UN SECTOR DETERMINADO Y LOS MUESTRA CON SU RESPECTIVO SUELDO
        // GET: api/Personas/5
        [HttpGet("{id}")]
        public IEnumerable<Persona> GetPersona(int id)
        {
            var persona= (from _personas in _context.Personas
                         join _zona in _context.Zonas on _personas.CodZona equals _zona.CodZona
                         where _personas.CodZona == id
                         select new Persona
                         {
                             CodPersona = _personas.CodPersona,
                             NomPersona = _personas.NomPersona,
                             CodZona = _personas.CodZona,
                             Sueldo = _personas.Sueldo,
                         }).ToList();

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, Persona persona)
        {
            if (id != persona.CodPersona)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.CodPersona }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.CodPersona == id);
        }
    }
}
