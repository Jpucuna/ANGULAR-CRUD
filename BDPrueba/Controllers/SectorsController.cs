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
    public class SectorsController : ControllerBase
    {
        private readonly PruebaContext _context;

        public SectorsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Sectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSectors()
        {
            return await _context.Sectors.ToListAsync();
        }

        // GET: api/Sectors/5
        [HttpGet("{id}")]
        public IEnumerable<Zona> GetZona(int id)
        {
            var resultado = (from _zonaDesc in _context.Zonas
                             join _secId in _context.Sectors on _zonaDesc.CodSector equals _secId.CodSector
                             where _zonaDesc.CodSector == id
                             select new Zona
                             {
                                 DesZona = _zonaDesc.DesZona
                             }).ToList();

                return resultado;
            
        }

        // PUT: api/Sectors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(int id, Sector sector)
        {
            if (id != sector.CodSector)
            {
                return BadRequest();
            }

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
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

        // POST: api/Sectors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.CodSector }, sector);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectorExists(int id)
        {
            return _context.Sectors.Any(e => e.CodSector == id);
        }
    }
}
